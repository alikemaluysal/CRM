using NArchitecture.Core.Application.Dtos;

namespace Application.Features.StatusTypes.Queries.GetList;

public class GetListStatusTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}