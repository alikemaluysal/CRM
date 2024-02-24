using NArchitecture.Core.Application.Responses;

namespace Application.Features.StatusTypes.Queries.GetById;

public class GetByIdStatusTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}