using NArchitecture.Core.Application.Responses;

namespace Application.Features.RequestStatuses.Commands.Delete;

public class DeletedRequestStatusResponse : IResponse
{
    public Guid Id { get; set; }
}