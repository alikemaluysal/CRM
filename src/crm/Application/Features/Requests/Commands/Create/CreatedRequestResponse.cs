using NArchitecture.Core.Application.Responses;

namespace Application.Features.Requests.Commands.Create;

public class CreatedRequestResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CustomerUserId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public Guid RequestStatusId { get; set; }
    public string Description { get; set; }
}