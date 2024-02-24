
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class StatusType : Entity<Guid>
{
    public string Name { get; set; }

    public virtual List<Customer>? Customers { get; set; }
}