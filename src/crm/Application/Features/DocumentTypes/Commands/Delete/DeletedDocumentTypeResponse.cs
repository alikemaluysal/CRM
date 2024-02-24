using NArchitecture.Core.Application.Responses;

namespace Application.Features.DocumentTypes.Commands.Delete;

public class DeletedDocumentTypeResponse : IResponse
{
    public Guid Id { get; set; }
}