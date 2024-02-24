using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OfferStatusRepository : EfRepositoryBase<OfferStatus, Guid, BaseDbContext>, IOfferStatusRepository
{
    public OfferStatusRepository(BaseDbContext context) : base(context)
    {
    }
}