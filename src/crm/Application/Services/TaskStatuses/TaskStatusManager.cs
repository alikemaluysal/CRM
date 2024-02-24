using Application.Features.TaskStatuses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Application.Services.TaskStatuses;

public class TaskStatusManager : ITaskStatusService
{
    private readonly ITaskStatusRepository _taskStatusRepository;
    private readonly TaskStatusBusinessRules _taskStatusBusinessRules;

    public TaskStatusManager(ITaskStatusRepository taskStatusRepository, TaskStatusBusinessRules taskStatusBusinessRules)
    {
        _taskStatusRepository = taskStatusRepository;
        _taskStatusBusinessRules = taskStatusBusinessRules;
    }

    public async Task<TaskStatus?> GetAsync(
        Expression<Func<TaskStatus, bool>> predicate,
        Func<IQueryable<TaskStatus>, IIncludableQueryable<TaskStatus, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TaskStatus? taskStatus = await _taskStatusRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return taskStatus;
    }

    public async Task<IPaginate<TaskStatus>?> GetListAsync(
        Expression<Func<TaskStatus, bool>>? predicate = null,
        Func<IQueryable<TaskStatus>, IOrderedQueryable<TaskStatus>>? orderBy = null,
        Func<IQueryable<TaskStatus>, IIncludableQueryable<TaskStatus, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TaskStatus> taskStatusList = await _taskStatusRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return taskStatusList;
    }

    public async Task<TaskStatus> AddAsync(TaskStatus taskStatus)
    {
        TaskStatus addedTaskStatus = await _taskStatusRepository.AddAsync(taskStatus);

        return addedTaskStatus;
    }

    public async Task<TaskStatus> UpdateAsync(TaskStatus taskStatus)
    {
        TaskStatus updatedTaskStatus = await _taskStatusRepository.UpdateAsync(taskStatus);

        return updatedTaskStatus;
    }

    public async Task<TaskStatus> DeleteAsync(TaskStatus taskStatus, bool permanent = false)
    {
        TaskStatus deletedTaskStatus = await _taskStatusRepository.DeleteAsync(taskStatus);

        return deletedTaskStatus;
    }
}
