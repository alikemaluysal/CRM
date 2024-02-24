using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Document : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid RequestId { get; set; }
    public string DocumentFileName { get; set; }
    public Guid DocumentTypeId { get; set; }

    #region Navigation Properties

    public virtual User? User { get; set; }
    public virtual Request Request { get; set; }
    public virtual DocumentType DocumentType { get; set; }

    #endregion
}