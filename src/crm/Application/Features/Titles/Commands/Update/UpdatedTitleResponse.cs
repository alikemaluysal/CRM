using NArchitecture.Core.Application.Responses;

namespace Application.Features.Titles.Commands.Update;

public class UpdatedTitleResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}