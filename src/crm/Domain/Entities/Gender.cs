using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Gender : Entity<Guid>
{
    public string Name { get; set; }
}