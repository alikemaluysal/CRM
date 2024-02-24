using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Region : Entity<Guid>
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
}