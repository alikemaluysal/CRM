using Application.Features.Offers.Constants;
using Application.Features.Offers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Offers.Constants.OffersOperationClaims;

namespace Application.Features.Offers.Queries.GetById;

public class GetByIdOfferQuery : IRequest<GetByIdOfferResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdOfferQueryHandler : IRequestHandler<GetByIdOfferQuery, GetByIdOfferResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepository _offerRepository;
        private readonly OfferBusinessRules _offerBusinessRules;

        public GetByIdOfferQueryHandler(IMapper mapper, IOfferRepository offerRepository, OfferBusinessRules offerBusinessRules)
        {
            _mapper = mapper;
            _offerRepository = offerRepository;
            _offerBusinessRules = offerBusinessRules;
        }

        public async Task<GetByIdOfferResponse> Handle(GetByIdOfferQuery request, CancellationToken cancellationToken)
        {
            Offer? offer = await _offerRepository.GetAsync(predicate: o => o.Id == request.Id, cancellationToken: cancellationToken);
            await _offerBusinessRules.OfferShouldExistWhenSelected(offer);

            GetByIdOfferResponse response = _mapper.Map<GetByIdOfferResponse>(offer);
            return response;
        }
    }
}