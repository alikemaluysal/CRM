using NArchitecture.Core.Application.Responses;

namespace Application.Features.DocumentTypes.Commands.Update;

public class UpdatedDocumentTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}