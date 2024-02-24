using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Request : Entity<Guid>
{
    public Guid CustomerUserId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public Guid RequestStatusId { get; set; }
    public string Description { get; set; }


    #region Navigation Properties

    public virtual RequestStatus RequestStatus { get; set; }

    #endregion
}