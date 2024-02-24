using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserPhones;

public interface IUserPhoneService
{
    Task<UserPhone?> GetAsync(
        Expression<Func<UserPhone, bool>> predicate,
        Func<IQueryable<UserPhone>, IIncludableQueryable<UserPhone, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserPhone>?> GetListAsync(
        Expression<Func<UserPhone, bool>>? predicate = null,
        Func<IQueryable<UserPhone>, IOrderedQueryable<UserPhone>>? orderBy = null,
        Func<IQueryable<UserPhone>, IIncludableQueryable<UserPhone, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserPhone> AddAsync(UserPhone userPhone);
    Task<UserPhone> UpdateAsync(UserPhone userPhone);
    Task<UserPhone> DeleteAsync(UserPhone userPhone, bool permanent = false);
}
