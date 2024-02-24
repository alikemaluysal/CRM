using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class OfferStatus : Entity<Guid>
{
    public string Name { get; set; }
}