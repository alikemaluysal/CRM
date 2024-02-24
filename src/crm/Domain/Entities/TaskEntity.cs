using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class TaskEntity : Entity<Guid>
{
    public Guid RequestId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public DateTime TaskStartDate { get; set; }
    public DateTime TaskEndDate { get; set; }
    public string? Description { get; set; }
    public Guid TaskStatusId { get; set; }

    #region Navigation Properties

    public virtual Request? Request { get; set; }
    public virtual User? EmployeeUser { get; set; }
    public virtual TaskStatus? TaskStatus { get; set; }

    #endregion
}