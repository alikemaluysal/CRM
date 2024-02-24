using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Offer : Entity<Guid>
{
    public Guid RequestId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public DateTime? OfferDate { get; set; }
    public decimal BidAmount { get; set; }
    public Guid OfferStatusId { get; set; }


    #region Navigation Properties

    public virtual User? EmployeeUser { get; set; }
    public virtual Request Request { get; set; }
    public virtual OfferStatus OfferStatus { get; set; }

    #endregion
}