
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Department : Entity<Guid>
{
    public string? Name { get; set; }

}