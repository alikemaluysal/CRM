using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOfferRepository : IAsyncRepository<Offer, Guid>, IRepository<Offer, Guid>
{
}