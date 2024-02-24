using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserEmails;

public interface IUserEmailService
{
    Task<UserEmail?> GetAsync(
        Expression<Func<UserEmail, bool>> predicate,
        Func<IQueryable<UserEmail>, IIncludableQueryable<UserEmail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserEmail>?> GetListAsync(
        Expression<Func<UserEmail, bool>>? predicate = null,
        Func<IQueryable<UserEmail>, IOrderedQueryable<UserEmail>>? orderBy = null,
        Func<IQueryable<UserEmail>, IIncludableQueryable<UserEmail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserEmail> AddAsync(UserEmail userEmail);
    Task<UserEmail> UpdateAsync(UserEmail userEmail);
    Task<UserEmail> DeleteAsync(UserEmail userEmail, bool permanent = false);
}
