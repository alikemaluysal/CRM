using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Offers;

public interface IOfferService
{
    Task<Offer?> GetAsync(
        Expression<Func<Offer, bool>> predicate,
        Func<IQueryable<Offer>, IIncludableQueryable<Offer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Offer>?> GetListAsync(
        Expression<Func<Offer, bool>>? predicate = null,
        Func<IQueryable<Offer>, IOrderedQueryable<Offer>>? orderBy = null,
        Func<IQueryable<Offer>, IIncludableQueryable<Offer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Offer> AddAsync(Offer offer);
    Task<Offer> UpdateAsync(Offer offer);
    Task<Offer> DeleteAsync(Offer offer, bool permanent = false);
}
