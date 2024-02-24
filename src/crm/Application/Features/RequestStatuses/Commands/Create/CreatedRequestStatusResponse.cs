using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequestStatuses.Commands.Create;

public class CreatedRequestStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}