using NArchitecture.Core.Application.Dtos;

namespace Application.Features.TaskStatuses.Queries.GetList;

public class GetListTaskStatusListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}