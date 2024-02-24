using Application.Features.StatusTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.StatusTypes.Constants.StatusTypesOperationClaims;

namespace Application.Features.StatusTypes.Queries.GetList;

public class GetListStatusTypeQuery : IRequest<GetListResponse<GetListStatusTypeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListStatusTypes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetStatusTypes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListStatusTypeQueryHandler : IRequestHandler<GetListStatusTypeQuery, GetListResponse<GetListStatusTypeListItemDto>>
    {
        private readonly IStatusTypeRepository _statusTypeRepository;
        private readonly IMapper _mapper;

        public GetListStatusTypeQueryHandler(IStatusTypeRepository statusTypeRepository, IMapper mapper)
        {
            _statusTypeRepository = statusTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStatusTypeListItemDto>> Handle(GetListStatusTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StatusType> statusTypes = await _statusTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStatusTypeListItemDto> response = _mapper.Map<GetListResponse<GetListStatusTypeListItemDto>>(statusTypes);
            return response;
        }
    }
}