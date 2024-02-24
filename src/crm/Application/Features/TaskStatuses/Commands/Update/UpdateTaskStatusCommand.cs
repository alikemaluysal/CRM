using Application.Features.TaskStatuses.Constants;
using Application.Features.TaskStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.TaskStatuses.Constants.TaskStatusOperationClaims;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Application.Features.TaskStatuses.Commands.Update;

public class UpdateTaskStatusCommand : IRequest<UpdatedTaskStatusResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public string[] Roles => [Admin, Write, TaskStatusOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTaskStatus"];

    public class UpdateTaskStatusCommandHandler : IRequestHandler<UpdateTaskStatusCommand, UpdatedTaskStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskStatusRepository _taskStatusRepository;
        private readonly TaskStatusBusinessRules _taskStatusBusinessRules;

        public UpdateTaskStatusCommandHandler(IMapper mapper, ITaskStatusRepository taskStatusRepository,
                                         TaskStatusBusinessRules taskStatusBusinessRules)
        {
            _mapper = mapper;
            _taskStatusRepository = taskStatusRepository;
            _taskStatusBusinessRules = taskStatusBusinessRules;
        }

        public async Task<UpdatedTaskStatusResponse> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
        {
            TaskStatus? taskStatus = await _taskStatusRepository.GetAsync(predicate: ts => ts.Id == request.Id, cancellationToken: cancellationToken);
            await _taskStatusBusinessRules.TaskStatusShouldExistWhenSelected(taskStatus);
            taskStatus = _mapper.Map(request, taskStatus);

            await _taskStatusRepository.UpdateAsync(taskStatus!);

            UpdatedTaskStatusResponse response = _mapper.Map<UpdatedTaskStatusResponse>(taskStatus);
            return response;
        }
    }
}