using NArchitecture.Core.Application.Responses;

namespace Application.Features.StatusTypes.Commands.Create;

public class CreatedStatusTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}