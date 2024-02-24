using Application.Features.TaskStatuses.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.TaskStatuses.Constants.TaskStatusOperationClaims;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Application.Features.TaskStatuses.Queries.GetList;

public class GetListTaskStatusQuery : IRequest<GetListResponse<GetListTaskStatusListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListTaskStatus({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetTaskStatus";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListTaskStatusQueryHandler : IRequestHandler<GetListTaskStatusQuery, GetListResponse<GetListTaskStatusListItemDto>>
    {
        private readonly ITaskStatusRepository _taskStatusRepository;
        private readonly IMapper _mapper;

        public GetListTaskStatusQueryHandler(ITaskStatusRepository taskStatusRepository, IMapper mapper)
        {
            _taskStatusRepository = taskStatusRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTaskStatusListItemDto>> Handle(GetListTaskStatusQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TaskStatus> taskStatus = await _taskStatusRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTaskStatusListItemDto> response = _mapper.Map<GetListResponse<GetListTaskStatusListItemDto>>(taskStatus);
            return response;
        }
    }
}