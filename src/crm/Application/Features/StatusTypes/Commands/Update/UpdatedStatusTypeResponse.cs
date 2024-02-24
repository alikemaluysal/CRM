using NArchitecture.Core.Application.Responses;

namespace Application.Features.StatusTypes.Commands.Update;

public class UpdatedStatusTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}