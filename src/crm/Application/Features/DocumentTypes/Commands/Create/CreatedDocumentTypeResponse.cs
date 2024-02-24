using NArchitecture.Core.Application.Responses;

namespace Application.Features.DocumentTypes.Commands.Create;

public class CreatedDocumentTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}