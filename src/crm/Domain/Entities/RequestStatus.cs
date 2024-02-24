using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class RequestStatus : Entity<Guid>
{
    public string Name { get; set; }
}
