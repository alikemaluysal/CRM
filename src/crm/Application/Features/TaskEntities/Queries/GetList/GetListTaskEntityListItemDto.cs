using NArchitecture.Core.Application.Dtos;

namespace Application.Features.TaskEntities.Queries.GetList;

public class GetListTaskEntityListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid RequestId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public DateTime TaskStartDate { get; set; }
    public DateTime TaskEndDate { get; set; }
    public string? Description { get; set; }
    public Guid TaskStatusId { get; set; }
}