using NArchitecture.Core.Application.Responses;

namespace Application.Features.TaskStatuses.Commands.Update;

public class UpdatedTaskStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}