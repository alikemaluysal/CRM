using NArchitecture.Core.Application.Dtos;

namespace Application.Features.RequestStatuses.Queries.GetList;

public class GetListRequestStatusListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}