using Application.Features.RequestStatuses.Constants;
using Application.Features.RequestStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.RequestStatuses.Constants.RequestStatusOperationClaims;

namespace Application.Features.RequestStatuses.Commands.Create;

public class CreateRequestStatusCommand : IRequest<CreatedRequestStatusResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, RequestStatusOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRequestStatus"];

    public class CreateRequestStatusCommandHandler : IRequestHandler<CreateRequestStatusCommand, CreatedRequestStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestStatusRepository _requestStatusRepository;
        private readonly RequestStatusBusinessRules _requestStatusBusinessRules;

        public CreateRequestStatusCommandHandler(IMapper mapper, IRequestStatusRepository requestStatusRepository,
                                         RequestStatusBusinessRules requestStatusBusinessRules)
        {
            _mapper = mapper;
            _requestStatusRepository = requestStatusRepository;
            _requestStatusBusinessRules = requestStatusBusinessRules;
        }

        public async Task<CreatedRequestStatusResponse> Handle(CreateRequestStatusCommand request, CancellationToken cancellationToken)
        {
            RequestStatus requestStatus = _mapper.Map<RequestStatus>(request);

            await _requestStatusRepository.AddAsync(requestStatus);

            CreatedRequestStatusResponse response = _mapper.Map<CreatedRequestStatusResponse>(requestStatus);
            return response;
        }
    }
}