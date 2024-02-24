using Application.Features.StatusTypes.Constants;
using Application.Features.StatusTypes.Constants;
using Application.Features.StatusTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.StatusTypes.Constants.StatusTypesOperationClaims;

namespace Application.Features.StatusTypes.Commands.Delete;

public class DeleteStatusTypeCommand : IRequest<DeletedStatusTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, StatusTypesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetStatusTypes"];

    public class DeleteStatusTypeCommandHandler : IRequestHandler<DeleteStatusTypeCommand, DeletedStatusTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStatusTypeRepository _statusTypeRepository;
        private readonly StatusTypeBusinessRules _statusTypeBusinessRules;

        public DeleteStatusTypeCommandHandler(IMapper mapper, IStatusTypeRepository statusTypeRepository,
                                         StatusTypeBusinessRules statusTypeBusinessRules)
        {
            _mapper = mapper;
            _statusTypeRepository = statusTypeRepository;
            _statusTypeBusinessRules = statusTypeBusinessRules;
        }

        public async Task<DeletedStatusTypeResponse> Handle(DeleteStatusTypeCommand request, CancellationToken cancellationToken)
        {
            StatusType? statusType = await _statusTypeRepository.GetAsync(predicate: st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _statusTypeBusinessRules.StatusTypeShouldExistWhenSelected(statusType);

            await _statusTypeRepository.DeleteAsync(statusType!);

            DeletedStatusTypeResponse response = _mapper.Map<DeletedStatusTypeResponse>(statusType);
            return response;
        }
    }
}