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

namespace Application.Features.StatusTypes.Commands.Create;

public class CreateStatusTypeCommand : IRequest<CreatedStatusTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, StatusTypesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetStatusTypes"];

    public class CreateStatusTypeCommandHandler : IRequestHandler<CreateStatusTypeCommand, CreatedStatusTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStatusTypeRepository _statusTypeRepository;
        private readonly StatusTypeBusinessRules _statusTypeBusinessRules;

        public CreateStatusTypeCommandHandler(IMapper mapper, IStatusTypeRepository statusTypeRepository,
                                         StatusTypeBusinessRules statusTypeBusinessRules)
        {
            _mapper = mapper;
            _statusTypeRepository = statusTypeRepository;
            _statusTypeBusinessRules = statusTypeBusinessRules;
        }

        public async Task<CreatedStatusTypeResponse> Handle(CreateStatusTypeCommand request, CancellationToken cancellationToken)
        {
            StatusType statusType = _mapper.Map<StatusType>(request);

            await _statusTypeRepository.AddAsync(statusType);

            CreatedStatusTypeResponse response = _mapper.Map<CreatedStatusTypeResponse>(statusType);
            return response;
        }
    }
}