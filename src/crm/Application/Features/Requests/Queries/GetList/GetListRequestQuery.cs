using Application.Features.Requests.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Requests.Constants.RequestsOperationClaims;

namespace Application.Features.Requests.Queries.GetList;

public class GetListRequestQuery : IRequest<GetListResponse<GetListRequestListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListRequests({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetRequests";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListRequestQueryHandler : IRequestHandler<GetListRequestQuery, GetListResponse<GetListRequestListItemDto>>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public GetListRequestQueryHandler(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRequestListItemDto>> Handle(GetListRequestQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Request> requests = await _requestRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRequestListItemDto> response = _mapper.Map<GetListResponse<GetListRequestListItemDto>>(requests);
            return response;
        }
    }
}