using Application.Features.TaskStatuses.Constants;
using Application.Features.TaskStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.TaskStatuses.Constants.TaskStatusOperationClaims;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Application.Features.TaskStatuses.Queries.GetById;

public class GetByIdTaskStatusQuery : IRequest<GetByIdTaskStatusResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdTaskStatusQueryHandler : IRequestHandler<GetByIdTaskStatusQuery, GetByIdTaskStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskStatusRepository _taskStatusRepository;
        private readonly TaskStatusBusinessRules _taskStatusBusinessRules;

        public GetByIdTaskStatusQueryHandler(IMapper mapper, ITaskStatusRepository taskStatusRepository, TaskStatusBusinessRules taskStatusBusinessRules)
        {
            _mapper = mapper;
            _taskStatusRepository = taskStatusRepository;
            _taskStatusBusinessRules = taskStatusBusinessRules;
        }

        public async Task<GetByIdTaskStatusResponse> Handle(GetByIdTaskStatusQuery request, CancellationToken cancellationToken)
        {
            TaskStatus? taskStatus = await _taskStatusRepository.GetAsync(predicate: ts => ts.Id == request.Id, cancellationToken: cancellationToken);
            await _taskStatusBusinessRules.TaskStatusShouldExistWhenSelected(taskStatus);

            GetByIdTaskStatusResponse response = _mapper.Map<GetByIdTaskStatusResponse>(taskStatus);
            return response;
        }
    }
}