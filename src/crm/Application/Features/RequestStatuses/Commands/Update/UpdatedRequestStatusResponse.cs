using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequestStatuses.Commands.Update;

public class UpdatedRequestStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}