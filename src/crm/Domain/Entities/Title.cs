using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Title : Entity<Guid>
{
    public string Name { get; set; }
}