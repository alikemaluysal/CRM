using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TaskEntities;

public interface ITaskEntityService
{
    Task<TaskEntity?> GetAsync(
        Expression<Func<TaskEntity, bool>> predicate,
        Func<IQueryable<TaskEntity>, IIncludableQueryable<TaskEntity, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TaskEntity>?> GetListAsync(
        Expression<Func<TaskEntity, bool>>? predicate = null,
        Func<IQueryable<TaskEntity>, IOrderedQueryable<TaskEntity>>? orderBy = null,
        Func<IQueryable<TaskEntity>, IIncludableQueryable<TaskEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TaskEntity> AddAsync(TaskEntity taskEntity);
    Task<TaskEntity> UpdateAsync(TaskEntity taskEntity);
    Task<TaskEntity> DeleteAsync(TaskEntity taskEntity, bool permanent = false);
}
