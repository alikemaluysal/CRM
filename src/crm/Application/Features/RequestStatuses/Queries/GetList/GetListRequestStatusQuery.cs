using Application.Features.RequestStatuses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.RequestStatuses.Constants.RequestStatusOperationClaims;

namespace Application.Features.RequestStatuses.Queries.GetList;

public class GetListRequestStatusQuery : IRequest<GetListResponse<GetListRequestStatusListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListRequestStatus({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetRequestStatus";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListRequestStatusQueryHandler : IRequestHandler<GetListRequestStatusQuery, GetListResponse<GetListRequestStatusListItemDto>>
    {
        private readonly IRequestStatusRepository _requestStatusRepository;
        private readonly IMapper _mapper;

        public GetListRequestStatusQueryHandler(IRequestStatusRepository requestStatusRepository, IMapper mapper)
        {
            _requestStatusRepository = requestStatusRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRequestStatusListItemDto>> Handle(GetListRequestStatusQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RequestStatus> requestStatus = await _requestStatusRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRequestStatusListItemDto> response = _mapper.Map<GetListResponse<GetListRequestStatusListItemDto>>(requestStatus);
            return response;
        }
    }
}