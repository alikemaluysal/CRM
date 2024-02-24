using NArchitecture.Core.Application.Responses;

namespace Application.Features.Requests.Commands.Delete;

public class DeletedRequestResponse : IResponse
{
    public Guid Id { get; set; }
}