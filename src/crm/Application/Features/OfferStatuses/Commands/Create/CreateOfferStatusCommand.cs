using Application.Features.OfferStatuses.Constants;
using Application.Features.OfferStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.OfferStatuses.Constants.OfferStatusOperationClaims;

namespace Application.Features.OfferStatuses.Commands.Create;

public class CreateOfferStatusCommand : IRequest<CreatedOfferStatusResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, OfferStatusOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOfferStatus"];

    public class CreateOfferStatusCommandHandler : IRequestHandler<CreateOfferStatusCommand, CreatedOfferStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferStatusRepository _offerStatusRepository;
        private readonly OfferStatusBusinessRules _offerStatusBusinessRules;

        public CreateOfferStatusCommandHandler(IMapper mapper, IOfferStatusRepository offerStatusRepository,
                                         OfferStatusBusinessRules offerStatusBusinessRules)
        {
            _mapper = mapper;
            _offerStatusRepository = offerStatusRepository;
            _offerStatusBusinessRules = offerStatusBusinessRules;
        }

        public async Task<CreatedOfferStatusResponse> Handle(CreateOfferStatusCommand request, CancellationToken cancellationToken)
        {
            OfferStatus offerStatus = _mapper.Map<OfferStatus>(request);

            await _offerStatusRepository.AddAsync(offerStatus);

            CreatedOfferStatusResponse response = _mapper.Map<CreatedOfferStatusResponse>(offerStatus);
            return response;
        }
    }
}