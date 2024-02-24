using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class UserAddress : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string Description { get; set; }
    public AddressTypeEnum AddressType { get; set; }

    #region Navigation Properties

    public virtual User? User { get; set; }

    #endregion
}