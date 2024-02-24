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

namespace Application.Features.OfferStatuses.Commands.Update;

public class UpdateOfferStatusCommand : IRequest<UpdatedOfferStatusResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, OfferStatusOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOfferStatus"];

    public class UpdateOfferStatusCommandHandler : IRequestHandler<UpdateOfferStatusCommand, UpdatedOfferStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferStatusRepository _offerStatusRepository;
        private readonly OfferStatusBusinessRules _offerStatusBusinessRules;

        public UpdateOfferStatusCommandHandler(IMapper mapper, IOfferStatusRepository offerStatusRepository,
                                         OfferStatusBusinessRules offerStatusBusinessRules)
        {
            _mapper = mapper;
            _offerStatusRepository = offerStatusRepository;
            _offerStatusBusinessRules = offerStatusBusinessRules;
        }

        public async Task<UpdatedOfferStatusResponse> Handle(UpdateOfferStatusCommand request, CancellationToken cancellationToken)
        {
            OfferStatus? offerStatus = await _offerStatusRepository.GetAsync(predicate: os => os.Id == request.Id, cancellationToken: cancellationToken);
            await _offerStatusBusinessRules.OfferStatusShouldExistWhenSelected(offerStatus);
            offerStatus = _mapper.Map(request, offerStatus);

            await _offerStatusRepository.UpdateAsync(offerStatus!);

            UpdatedOfferStatusResponse response = _mapper.Map<UpdatedOfferStatusResponse>(offerStatus);
            return response;
        }
    }
}