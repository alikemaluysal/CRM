using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Requests.Queries.GetList;

public class GetListRequestListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CustomerUserId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public Guid RequestStatusId { get; set; }
    public string Description { get; set; }
}