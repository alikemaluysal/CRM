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

namespace Application.Features.RequestStatuses.Commands.Update;

public class UpdateRequestStatusCommand : IRequest<UpdatedRequestStatusResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, RequestStatusOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRequestStatus"];

    public class UpdateRequestStatusCommandHandler : IRequestHandler<UpdateRequestStatusCommand, UpdatedRequestStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestStatusRepository _requestStatusRepository;
        private readonly RequestStatusBusinessRules _requestStatusBusinessRules;

        public UpdateRequestStatusCommandHandler(IMapper mapper, IRequestStatusRepository requestStatusRepository,
                                         RequestStatusBusinessRules requestStatusBusinessRules)
        {
            _mapper = mapper;
            _requestStatusRepository = requestStatusRepository;
            _requestStatusBusinessRules = requestStatusBusinessRules;
        }

        public async Task<UpdatedRequestStatusResponse> Handle(UpdateRequestStatusCommand request, CancellationToken cancellationToken)
        {
            RequestStatus? requestStatus = await _requestStatusRepository.GetAsync(predicate: rs => rs.Id == request.Id, cancellationToken: cancellationToken);
            await _requestStatusBusinessRules.RequestStatusShouldExistWhenSelected(requestStatus);
            requestStatus = _mapper.Map(request, requestStatus);

            await _requestStatusRepository.UpdateAsync(requestStatus!);

            UpdatedRequestStatusResponse response = _mapper.Map<UpdatedRequestStatusResponse>(requestStatus);
            return response;
        }
    }
}