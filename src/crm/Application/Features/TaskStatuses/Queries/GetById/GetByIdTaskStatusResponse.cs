using NArchitecture.Core.Application.Responses;

namespace Application.Features.TaskStatuses.Queries.GetById;

public class GetByIdTaskStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}