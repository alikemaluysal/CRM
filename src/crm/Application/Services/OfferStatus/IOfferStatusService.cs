using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OfferStatuses;

public interface IOfferStatusService
{
    Task<OfferStatus?> GetAsync(
        Expression<Func<OfferStatus, bool>> predicate,
        Func<IQueryable<OfferStatus>, IIncludableQueryable<OfferStatus, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<OfferStatus>?> GetListAsync(
        Expression<Func<OfferStatus, bool>>? predicate = null,
        Func<IQueryable<OfferStatus>, IOrderedQueryable<OfferStatus>>? orderBy = null,
        Func<IQueryable<OfferStatus>, IIncludableQueryable<OfferStatus, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<OfferStatus> AddAsync(OfferStatus offerStatus);
    Task<OfferStatus> UpdateAsync(OfferStatus offerStatus);
    Task<OfferStatus> DeleteAsync(OfferStatus offerStatus, bool permanent = false);
}
