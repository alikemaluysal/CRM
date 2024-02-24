using Application.Features.Offers.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Offers.Constants.OffersOperationClaims;

namespace Application.Features.Offers.Queries.GetList;

public class GetListOfferQuery : IRequest<GetListResponse<GetListOfferListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListOffers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetOffers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListOfferQueryHandler : IRequestHandler<GetListOfferQuery, GetListResponse<GetListOfferListItemDto>>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public GetListOfferQueryHandler(IOfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOfferListItemDto>> Handle(GetListOfferQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Offer> offers = await _offerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOfferListItemDto> response = _mapper.Map<GetListResponse<GetListOfferListItemDto>>(offers);
            return response;
        }
    }
}