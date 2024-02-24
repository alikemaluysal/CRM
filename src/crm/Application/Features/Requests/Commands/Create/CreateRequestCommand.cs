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

namespace Application.Features.Requests.Commands.Create;

public class CreateRequestCommand : IRequest<CreatedRequestResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid CustomerUserId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public Guid RequestStatusId { get; set; }
    public string Description { get; set; }

    public string[] Roles => [Admin, Write, RequestsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRequests"];

    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, CreatedRequestResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRequestRepository _requestRepository;
        private readonly RequestBusinessRules _requestBusinessRules;

        public CreateRequestCommandHandler(IMapper mapper, IRequestRepository requestRepository,
                                         RequestBusinessRules requestBusinessRules)
        {
            _mapper = mapper;
            _requestRepository = requestRepository;
            _requestBusinessRules = requestBusinessRules;
        }

        public async Task<CreatedRequestResponse> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            Request requestEntity = _mapper.Map<Request>(request);

            await _requestRepository.AddAsync(requestEntity);

            CreatedRequestResponse response = _mapper.Map<CreatedRequestResponse>(request);
            return response;
        }
    }
}