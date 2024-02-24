using Application.Features.Requests.Constants;
using Application.Features.Requests.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Requests.Constants.RequestsOperationClaims;

namespace Application.Features.Requests.Commands.Update;

public class UpdateRequestCommand : IRequest<UpdatedRequestResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid CustomerUserId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public Guid RequestStatusId { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, RequestsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRequests"];

    public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand, UpdatedRequestResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestRepository _requestRepository;
        private readonly RequestBusinessRules _requestBusinessRules;

        public UpdateRequestCommandHandler(IMapper mapper, IRequestRepository requestRepository,
                                         RequestBusinessRules requestBusinessRules)
        {
            _mapper = mapper;
            _requestRepository = requestRepository;
            _requestBusinessRules = requestBusinessRules;
        }

        public async Task<UpdatedRequestResponse> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            Request? requestEntity = await _requestRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _requestBusinessRules.RequestShouldExistWhenSelected(requestEntity);
            request = _mapper.Map(requestEntity, request);

            await _requestRepository.UpdateAsync(requestEntity!);

            UpdatedRequestResponse response = _mapper.Map<UpdatedRequestResponse>(request);
            return response;
        }
    }
}