using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OfferRepository : EfRepositoryBase<Offer, Guid, BaseDbContext>, IOfferRepository
{
    public OfferRepository(BaseDbContext context) : base(context)
    {
    }
}