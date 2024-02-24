using NArchitecture.Core.Application.Responses;

namespace Application.Features.TaskStatuses.Commands.Delete;

public class DeletedTaskStatusResponse : IResponse
{
    public Guid Id { get; set; }
}