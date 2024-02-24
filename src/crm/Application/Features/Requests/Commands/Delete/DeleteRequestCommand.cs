using Application.Features.Requests.Constants;
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

namespace Application.Features.Requests.Commands.Delete;

public class DeleteRequestCommand : IRequest<DeletedRequestResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, RequestsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRequests"];

    public class DeleteRequestCommandHandler : IRequestHandler<DeleteRequestCommand, DeletedRequestResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestRepository _requestRepository;
        private readonly RequestBusinessRules _requestBusinessRules;

        public DeleteRequestCommandHandler(IMapper mapper, IRequestRepository requestRepository,
                                         RequestBusinessRules requestBusinessRules)
        {
            _mapper = mapper;
            _requestRepository = requestRepository;
            _requestBusinessRules = requestBusinessRules;
        }

        public async Task<DeletedRequestResponse> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
        {
            Request? requestEntity = await _requestRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _requestBusinessRules.RequestShouldExistWhenSelected(requestEntity);

            await _requestRepository.DeleteAsync(requestEntity!);

            DeletedRequestResponse response = _mapper.Map<DeletedRequestResponse>(request);
            return response;
        }
    }
}