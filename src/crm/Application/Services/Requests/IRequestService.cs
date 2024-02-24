using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Requests;

public interface IRequestService
{
    Task<Request?> GetAsync(
        Expression<Func<Request, bool>> predicate,
        Func<IQueryable<Request>, IIncludableQueryable<Request, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Request>?> GetListAsync(
        Expression<Func<Request, bool>>? predicate = null,
        Func<IQueryable<Request>, IOrderedQueryable<Request>>? orderBy = null,
        Func<IQueryable<Request>, IIncludableQueryable<Request, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Request> AddAsync(Request request);
    Task<Request> UpdateAsync(Request request);
    Task<Request> DeleteAsync(Request request, bool permanent = false);
}
