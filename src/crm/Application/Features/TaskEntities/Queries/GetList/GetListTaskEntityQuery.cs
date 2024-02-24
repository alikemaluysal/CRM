using Application.Features.TaskEntities.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.TaskEntities.Constants.TaskEntitiesOperationClaims;

namespace Application.Features.TaskEntities.Queries.GetList;

public class GetListTaskEntityQuery : IRequest<GetListResponse<GetListTaskEntityListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListTaskEntities({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetTaskEntities";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTaskEntityQueryHandler : IRequestHandler<GetListTaskEntityQuery, GetListResponse<GetListTaskEntityListItemDto>>
    {
        private readonly ITaskEntityRepository _taskEntityRepository;
        private readonly IMapper _mapper;

        public GetListTaskEntityQueryHandler(ITaskEntityRepository taskEntityRepository, IMapper mapper)
        {
            _taskEntityRepository = taskEntityRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTaskEntityListItemDto>> Handle(GetListTaskEntityQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TaskEntity> taskEntities = await _taskEntityRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTaskEntityListItemDto> response = _mapper.Map<GetListResponse<GetListTaskEntityListItemDto>>(taskEntities);
            return response;
        }
    }
}