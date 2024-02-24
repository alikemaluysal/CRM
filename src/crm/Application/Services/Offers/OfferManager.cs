using Application.Features.Offers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Offers;

public class OfferManager : IOfferService
{
    private readonly IOfferRepository _offerRepository;
    private readonly OfferBusinessRules _offerBusinessRules;

    public OfferManager(IOfferRepository offerRepository, OfferBusinessRules offerBusinessRules)
    {
        _offerRepository = offerRepository;
        _offerBusinessRules = offerBusinessRules;
    }

    public async Task<Offer?> GetAsync(
        Expression<Func<Offer, bool>> predicate,
        Func<IQueryable<Offer>, IIncludableQueryable<Offer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Offer? offer = await _offerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return offer;
    }

    public async Task<IPaginate<Offer>?> GetListAsync(
        Expression<Func<Offer, bool>>? predicate = null,
        Func<IQueryable<Offer>, IOrderedQueryable<Offer>>? orderBy = null,
        Func<IQueryable<Offer>, IIncludableQueryable<Offer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Offer> offerList = await _offerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return offerList;
    }

    public async Task<Offer> AddAsync(Offer offer)
    {
        Offer addedOffer = await _offerRepository.AddAsync(offer);

        return addedOffer;
    }

    public async Task<Offer> UpdateAsync(Offer offer)
    {
        Offer updatedOffer = await _offerRepository.UpdateAsync(offer);

        return updatedOffer;
    }

    public async Task<Offer> DeleteAsync(Offer offer, bool permanent = false)
    {
        Offer deletedOffer = await _offerRepository.DeleteAsync(offer);

        return deletedOffer;
    }
}
