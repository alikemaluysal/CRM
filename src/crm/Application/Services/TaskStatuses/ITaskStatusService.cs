using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Application.Services.TaskStatuses;

public interface ITaskStatusService
{
    Task<TaskStatus?> GetAsync(
        Expression<Func<TaskStatus, bool>> predicate,
        Func<IQueryable<TaskStatus>, IIncludableQueryable<TaskStatus, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TaskStatus>?> GetListAsync(
        Expression<Func<TaskStatus, bool>>? predicate = null,
        Func<IQueryable<TaskStatus>, IOrderedQueryable<TaskStatus>>? orderBy = null,
        Func<IQueryable<TaskStatus>, IIncludableQueryable<TaskStatus, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TaskStatus> AddAsync(TaskStatus taskStatus);
    Task<TaskStatus> UpdateAsync(TaskStatus taskStatus);
    Task<TaskStatus> DeleteAsync(TaskStatus taskStatus, bool permanent = false);
}
