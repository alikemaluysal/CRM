using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Notification : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsRead { get; set; }


    #region Navigation Properties

    public virtual User? User { get; set; }

    #endregion
}