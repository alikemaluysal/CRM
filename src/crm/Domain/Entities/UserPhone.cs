using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class UserPhone : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string? PhoneNumber { get; set; }
    public PhoneTypeEnum PhoneType { get; set; }

    #region Navigation Properties

    public virtual User? User { get; set; }

    #endregion
}