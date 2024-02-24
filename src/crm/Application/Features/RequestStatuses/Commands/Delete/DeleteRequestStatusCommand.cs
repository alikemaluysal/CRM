using Application.Features.RequestStatuses.Constants;
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

namespace Application.Features.RequestStatuses.Commands.Delete;

public class DeleteRequestStatusCommand : IRequest<DeletedRequestStatusResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, RequestStatusOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRequestStatus"];

    public class DeleteRequestStatusCommandHandler : IRequestHandler<DeleteRequestStatusCommand, DeletedRequestStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestStatusRepository _requestStatusRepository;
        private readonly RequestStatusBusinessRules _requestStatusBusinessRules;

        public DeleteRequestStatusCommandHandler(IMapper mapper, IRequestStatusRepository requestStatusRepository,
                                         RequestStatusBusinessRules requestStatusBusinessRules)
        {
            _mapper = mapper;
            _requestStatusRepository = requestStatusRepository;
            _requestStatusBusinessRules = requestStatusBusinessRules;
        }

        public async Task<DeletedRequestStatusResponse> Handle(DeleteRequestStatusCommand request, CancellationToken cancellationToken)
        {
            RequestStatus? requestStatus = await _requestStatusRepository.GetAsync(predicate: rs => rs.Id == request.Id, cancellationToken: cancellationToken);
            await _requestStatusBusinessRules.RequestStatusShouldExistWhenSelected(requestStatus);

            await _requestStatusRepository.DeleteAsync(requestStatus!);

            DeletedRequestStatusResponse response = _mapper.Map<DeletedRequestStatusResponse>(requestStatus);
            return response;
        }
    }
}