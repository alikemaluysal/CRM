using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Customer : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string? IdentityNumber { get; set; }
    public Guid? GenderId { get; set; }
    public Guid? TitleId { get; set; }
    public string? CompanyName { get; set; }
    public Guid? StatusTypeId { get; set; }
    public CustomerTypeEnum CustomerType { get; set; }
    public Guid? RegionId { get; set; }
    public DateTime BirthDate { get; set; }

    #region Navigation Properties

    public virtual User? User { get; set; }
    public virtual StatusType? StatusType { get; set; }
    public virtual Gender? Gender { get; set; }
    public virtual Title? Title { get; set; }
    public virtual Region? Region { get; set; }

    #endregion
}