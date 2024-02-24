using NArchitecture.Core.Application.Responses;

namespace Application.Features.Regions.Commands.Delete;

public class DeletedRegionResponse : IResponse
{
    public Guid Id { get; set; }
}