using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RequestStatuses;

public interface IRequestStatusService
{
    Task<RequestStatus?> GetAsync(
        Expression<Func<RequestStatus, bool>> predicate,
        Func<IQueryable<RequestStatus>, IIncludableQueryable<RequestStatus, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RequestStatus>?> GetListAsync(
        Expression<Func<RequestStatus, bool>>? predicate = null,
        Func<IQueryable<RequestStatus>, IOrderedQueryable<RequestStatus>>? orderBy = null,
        Func<IQueryable<RequestStatus>, IIncludableQueryable<RequestStatus, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RequestStatus> AddAsync(RequestStatus requestStatus);
    Task<RequestStatus> UpdateAsync(RequestStatus requestStatus);
    Task<RequestStatus> DeleteAsync(RequestStatus requestStatus, bool permanent = false);
}
