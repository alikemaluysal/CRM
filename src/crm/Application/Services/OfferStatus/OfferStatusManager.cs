using Application.Features.OfferStatuses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OfferStatuses;

public class OfferStatusManager : IOfferStatusService
{
    private readonly IOfferStatusRepository _offerStatusRepository;
    private readonly OfferStatusBusinessRules _offerStatusBusinessRules;

    public OfferStatusManager(IOfferStatusRepository offerStatusRepository, OfferStatusBusinessRules offerStatusBusinessRules)
    {
        _offerStatusRepository = offerStatusRepository;
        _offerStatusBusinessRules = offerStatusBusinessRules;
    }

    public async Task<OfferStatus?> GetAsync(
        Expression<Func<OfferStatus, bool>> predicate,
        Func<IQueryable<OfferStatus>, IIncludableQueryable<OfferStatus, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        OfferStatus? offerStatus = await _offerStatusRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return offerStatus;
    }

    public async Task<IPaginate<OfferStatus>?> GetListAsync(
        Expression<Func<OfferStatus, bool>>? predicate = null,
        Func<IQueryable<OfferStatus>, IOrderedQueryable<OfferStatus>>? orderBy = null,
        Func<IQueryable<OfferStatus>, IIncludableQueryable<OfferStatus, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<OfferStatus> offerStatusList = await _offerStatusRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return offerStatusList;
    }

    public async Task<OfferStatus> AddAsync(OfferStatus offerStatus)
    {
        OfferStatus addedOfferStatus = await _offerStatusRepository.AddAsync(offerStatus);

        return addedOfferStatus;
    }

    public async Task<OfferStatus> UpdateAsync(OfferStatus offerStatus)
    {
        OfferStatus updatedOfferStatus = await _offerStatusRepository.UpdateAsync(offerStatus);

        return updatedOfferStatus;
    }

    public async Task<OfferStatus> DeleteAsync(OfferStatus offerStatus, bool permanent = false)
    {
        OfferStatus deletedOfferStatus = await _offerStatusRepository.DeleteAsync(offerStatus);

        return deletedOfferStatus;
    }
}
