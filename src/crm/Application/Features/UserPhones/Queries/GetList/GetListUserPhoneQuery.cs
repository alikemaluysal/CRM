using Application.Features.UserPhones.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.UserPhones.Constants.UserPhonesOperationClaims;

namespace Application.Features.UserPhones.Queries.GetList;

public class GetListUserPhoneQuery : IRequest<GetListResponse<GetListUserPhoneListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListUserPhones({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetUserPhones";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListUserPhoneQueryHandler : IRequestHandler<GetListUserPhoneQuery, GetListResponse<GetListUserPhoneListItemDto>>
    {
        private readonly IUserPhoneRepository _userPhoneRepository;
        private readonly IMapper _mapper;

        public GetListUserPhoneQueryHandler(IUserPhoneRepository userPhoneRepository, IMapper mapper)
        {
            _userPhoneRepository = userPhoneRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserPhoneListItemDto>> Handle(GetListUserPhoneQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserPhone> userPhones = await _userPhoneRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserPhoneListItemDto> response = _mapper.Map<GetListResponse<GetListUserPhoneListItemDto>>(userPhones);
            return response;
        }
    }
}