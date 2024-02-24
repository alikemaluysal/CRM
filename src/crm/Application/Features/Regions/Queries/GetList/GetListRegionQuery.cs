using Application.Features.Regions.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Regions.Constants.RegionsOperationClaims;

namespace Application.Features.Regions.Queries.GetList;

public class GetListRegionQuery : IRequest<GetListResponse<GetListRegionListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListRegions({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetRegions";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListRegionQueryHandler : IRequestHandler<GetListRegionQuery, GetListResponse<GetListRegionListItemDto>>
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public GetListRegionQueryHandler(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRegionListItemDto>> Handle(GetListRegionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Region> regions = await _regionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRegionListItemDto> response = _mapper.Map<GetListResponse<GetListRegionListItemDto>>(regions);
            return response;
        }
    }
}