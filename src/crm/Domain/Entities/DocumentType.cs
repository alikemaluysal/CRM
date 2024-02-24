using NArchitecture.Core.Persistence.Repositories;


namespace Domain.Entities;

public class DocumentType : Entity<Guid>
{
    public string? Name { get; set; }
}
