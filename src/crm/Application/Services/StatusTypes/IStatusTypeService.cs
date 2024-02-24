using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StatusTypes;

public interface IStatusTypeService
{
    Task<StatusType?> GetAsync(
        Expression<Func<StatusType, bool>> predicate,
        Func<IQueryable<StatusType>, IIncludableQueryable<StatusType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StatusType>?> GetListAsync(
        Expression<Func<StatusType, bool>>? predicate = null,
        Func<IQueryable<StatusType>, IOrderedQueryable<StatusType>>? orderBy = null,
        Func<IQueryable<StatusType>, IIncludableQueryable<StatusType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StatusType> AddAsync(StatusType statusType);
    Task<StatusType> UpdateAsync(StatusType statusType);
    Task<StatusType> DeleteAsync(StatusType statusType, bool permanent = false);
}
