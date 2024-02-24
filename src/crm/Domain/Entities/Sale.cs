using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Sale : Entity<Guid>
{
    public Guid RequestId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal SaleAmount { get; set; }
    public string Description { get; set; }

    #region Navigation Properties

    public virtual User? EmployeeUser { get; set; }
    public virtual Request Request { get; set; }

    #endregion
}