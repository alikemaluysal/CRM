using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Setting : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string SettingKey { get; set; }
    public string SettingValue { get; set; }


    #region Navigation Properties

    public virtual User? User { get; set; }

    #endregion
}