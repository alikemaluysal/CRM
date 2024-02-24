using NArchitecture.Core.Application.Responses;

namespace Application.Features.TaskStatuses.Commands.Create;

public class CreatedTaskStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}