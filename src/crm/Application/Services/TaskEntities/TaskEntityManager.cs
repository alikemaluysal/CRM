using Application.Features.TaskEntities.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TaskEntities;

public class TaskEntityManager : ITaskEntityService
{
    private readonly ITaskEntityRepository _taskEntityRepository;
    private readonly TaskEntityBusinessRules _taskEntityBusinessRules;

    public TaskEntityManager(ITaskEntityRepository taskEntityRepository, TaskEntityBusinessRules taskEntityBusinessRules)
    {
        _taskEntityRepository = taskEntityRepository;
        _taskEntityBusinessRules = taskEntityBusinessRules;
    }

    public async Task<TaskEntity?> GetAsync(
        Expression<Func<TaskEntity, bool>> predicate,
        Func<IQueryable<TaskEntity>, IIncludableQueryable<TaskEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TaskEntity? taskEntity = await _taskEntityRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return taskEntity;
    }

    public async Task<IPaginate<TaskEntity>?> GetListAsync(
        Expression<Func<TaskEntity, bool>>? predicate = null,
        Func<IQueryable<TaskEntity>, IOrderedQueryable<TaskEntity>>? orderBy = null,
        Func<IQueryable<TaskEntity>, IIncludableQueryable<TaskEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TaskEntity> taskEntityList = await _taskEntityRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return taskEntityList;
    }

    public async Task<TaskEntity> AddAsync(TaskEntity taskEntity)
    {
        TaskEntity addedTaskEntity = await _taskEntityRepository.AddAsync(taskEntity);

        return addedTaskEntity;
    }

    public async Task<TaskEntity> UpdateAsync(TaskEntity taskEntity)
    {
        TaskEntity updatedTaskEntity = await _taskEntityRepository.UpdateAsync(taskEntity);

        return updatedTaskEntity;
    }

    public async Task<TaskEntity> DeleteAsync(TaskEntity taskEntity, bool permanent = false)
    {
        TaskEntity deletedTaskEntity = await _taskEntityRepository.DeleteAsync(taskEntity);

        return deletedTaskEntity;
    }
}
