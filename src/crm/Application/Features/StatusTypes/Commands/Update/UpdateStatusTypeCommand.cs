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

namespace Application.Features.StatusTypes.Commands.Update;

public class UpdateStatusTypeCommand : IRequest<UpdatedStatusTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, StatusTypesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetStatusTypes"];

    public class UpdateStatusTypeCommandHandler : IRequestHandler<UpdateStatusTypeCommand, UpdatedStatusTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStatusTypeRepository _statusTypeRepository;
        private readonly StatusTypeBusinessRules _statusTypeBusinessRules;

        public UpdateStatusTypeCommandHandler(IMapper mapper, IStatusTypeRepository statusTypeRepository,
                                         StatusTypeBusinessRules statusTypeBusinessRules)
        {
            _mapper = mapper;
            _statusTypeRepository = statusTypeRepository;
            _statusTypeBusinessRules = statusTypeBusinessRules;
        }

        public async Task<UpdatedStatusTypeResponse> Handle(UpdateStatusTypeCommand request, CancellationToken cancellationToken)
        {
            StatusType? statusType = await _statusTypeRepository.GetAsync(predicate: st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _statusTypeBusinessRules.StatusTypeShouldExistWhenSelected(statusType);
            statusType = _mapper.Map(request, statusType);

            await _statusTypeRepository.UpdateAsync(statusType!);

            UpdatedStatusTypeResponse response = _mapper.Map<UpdatedStatusTypeResponse>(statusType);
            return response;
        }
    }
}