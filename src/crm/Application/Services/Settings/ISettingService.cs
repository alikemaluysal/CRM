using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Settings;

public interface ISettingService
{
    Task<Setting?> GetAsync(
        Expression<Func<Setting, bool>> predicate,
        Func<IQueryable<Setting>, IIncludableQueryable<Setting, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Setting>?> GetListAsync(
        Expression<Func<Setting, bool>>? predicate = null,
        Func<IQueryable<Setting>, IOrderedQueryable<Setting>>? orderBy = null,
        Func<IQueryable<Setting>, IIncludableQueryable<Setting, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Setting> AddAsync(Setting setting);
    Task<Setting> UpdateAsync(Setting setting);
    Task<Setting> DeleteAsync(Setting setting, bool permanent = false);
}
