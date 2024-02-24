using NArchitecture.Core.Application.Responses;

namespace Application.Features.StatusTypes.Commands.Delete;

public class DeletedStatusTypeResponse : IResponse
{
    public Guid Id { get; set; }
}