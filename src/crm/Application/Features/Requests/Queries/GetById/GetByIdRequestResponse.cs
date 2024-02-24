using NArchitecture.Core.Application.Responses;

namespace Application.Features.Requests.Queries.GetById;

public class GetByIdRequestResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CustomerUserId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public Guid RequestStatusId { get; set; }
    public string Description { get; set; }
}