using NArchitecture.Core.Application.Responses;

namespace Application.Features.Regions.Commands.Create;

public class CreatedRegionResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
}