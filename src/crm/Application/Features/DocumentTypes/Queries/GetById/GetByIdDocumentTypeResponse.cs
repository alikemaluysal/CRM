using NArchitecture.Core.Application.Responses;

namespace Application.Features.DocumentTypes.Queries.GetById;

public class GetByIdDocumentTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}