using Application.Features.TaskStatuses.Constants;
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

namespace Application.Features.TaskStatuses.Commands.Delete;

public class DeleteTaskStatusCommand : IRequest<DeletedTaskStatusResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, TaskStatusOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTaskStatus"];

    public class DeleteTaskStatusCommandHandler : IRequestHandler<DeleteTaskStatusCommand, DeletedTaskStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskStatusRepository _taskStatusRepository;
        private readonly TaskStatusBusinessRules _taskStatusBusinessRules;

        public DeleteTaskStatusCommandHandler(IMapper mapper, ITaskStatusRepository taskStatusRepository,
                                         TaskStatusBusinessRules taskStatusBusinessRules)
        {
            _mapper = mapper;
            _taskStatusRepository = taskStatusRepository;
            _taskStatusBusinessRules = taskStatusBusinessRules;
        }

        public async Task<DeletedTaskStatusResponse> Handle(DeleteTaskStatusCommand request, CancellationToken cancellationToken)
        {
            TaskStatus? taskStatus = await _taskStatusRepository.GetAsync(predicate: ts => ts.Id == request.Id, cancellationToken: cancellationToken);
            await _taskStatusBusinessRules.TaskStatusShouldExistWhenSelected(taskStatus);

            await _taskStatusRepository.DeleteAsync(taskStatus!);

            DeletedTaskStatusResponse response = _mapper.Map<DeletedTaskStatusResponse>(taskStatus);
            return response;
        }
    }
}