using Application.Features.OfferStatuses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.OfferStatuses.Constants.OfferStatusOperationClaims;

namespace Application.Features.OfferStatuses.Queries.GetList;

public class GetListOfferStatusQuery : IRequest<GetListResponse<GetListOfferStatusListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListOfferStatus({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetOfferStatus";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListOfferStatusQueryHandler : IRequestHandler<GetListOfferStatusQuery, GetListResponse<GetListOfferStatusListItemDto>>
    {
        private readonly IOfferStatusRepository _offerStatusRepository;
        private readonly IMapper _mapper;

        public GetListOfferStatusQueryHandler(IOfferStatusRepository offerStatusRepository, IMapper mapper)
        {
            _offerStatusRepository = offerStatusRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOfferStatusListItemDto>> Handle(GetListOfferStatusQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OfferStatus> offerStatus = await _offerStatusRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOfferStatusListItemDto> response = _mapper.Map<GetListResponse<GetListOfferStatusListItemDto>>(offerStatus);
            return response;
        }
    }
}