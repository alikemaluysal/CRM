using NArchitecture.Core.Application.Responses;

namespace Application.Features.Documents.Commands.Delete;

public class DeletedDocumentResponse : IResponse
{
    public Guid Id { get; set; }
}