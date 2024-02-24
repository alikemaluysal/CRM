using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Documents.Queries.GetList;

public class GetListDocumentListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid RequestId { get; set; }
    public string DocumentFileName { get; set; }
    public Guid DocumentTypeId { get; set; }
}