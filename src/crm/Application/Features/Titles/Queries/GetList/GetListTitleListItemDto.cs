using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Titles.Queries.GetList;

public class GetListTitleListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}