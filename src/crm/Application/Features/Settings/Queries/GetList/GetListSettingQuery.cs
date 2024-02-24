using Application.Features.Settings.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Settings.Constants.SettingsOperationClaims;

namespace Application.Features.Settings.Queries.GetList;

public class GetListSettingQuery : IRequest<GetListResponse<GetListSettingListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListSettings({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetSettings";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSettingQueryHandler : IRequestHandler<GetListSettingQuery, GetListResponse<GetListSettingListItemDto>>
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;

        public GetListSettingQueryHandler(ISettingRepository settingRepository, IMapper mapper)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSettingListItemDto>> Handle(GetListSettingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Setting> settings = await _settingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSettingListItemDto> response = _mapper.Map<GetListResponse<GetListSettingListItemDto>>(settings);
            return response;
        }
    }
}