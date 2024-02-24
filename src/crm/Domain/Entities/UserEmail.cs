using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class UserEmail : Entity<Guid>
{
    public Guid? UserId { get; set; }
    public string? EmailAddress { get; set; }
    public EmailTypeEnum EmailType { get; set; }

    #region Navigation Properties

    public virtual User? User { get; set; }

    #endregion
}