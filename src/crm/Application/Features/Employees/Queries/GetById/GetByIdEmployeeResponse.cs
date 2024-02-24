using NArchitecture.Core.Application.Responses;

namespace Application.Features.Employees.Queries.GetById;

public class GetByIdEmployeeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? IdentityNumber { get; set; }
    public Guid? GenderId { get; set; }
    public Guid? TitleId { get; set; }
    public Guid? DepartmentId { get; set; }
    public DateTime? StartDate { get; set; }
    public Guid? StatusTypeId { get; set; }
    public Guid? RegionId { get; set; }
    public DateTime? BirthDate { get; set; }
    public Guid? ParentEmployeeId { get; set; }
}