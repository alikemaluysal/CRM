using NArchitecture.Core.Application.Responses;

namespace Application.Features.TaskEntities.Commands.Delete;

public class DeletedTaskEntityResponse : IResponse
{
    public Guid Id { get; set; }
}