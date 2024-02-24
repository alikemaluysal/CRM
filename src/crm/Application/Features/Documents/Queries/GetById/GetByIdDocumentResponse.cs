using NArchitecture.Core.Application.Responses;

namespace Application.Features.Documents.Queries.GetById;

public class GetByIdDocumentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid RequestId { get; set; }
    public string DocumentFileName { get; set; }
    public Guid DocumentTypeId { get; set; }
}