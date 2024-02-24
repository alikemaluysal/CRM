using NArchitecture.Core.Application.Responses;

namespace Application.Features.Titles.Commands.Create;

public class CreatedTitleResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}