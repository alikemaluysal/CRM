using NArchitecture.Core.Application.Dtos;

namespace Application.Features.DocumentTypes.Queries.GetList;

public class GetListDocumentTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}