using NArchitecture.Core.Application.Responses;

namespace Application.Features.Titles.Commands.Delete;

public class DeletedTitleResponse : IResponse
{
    public Guid Id { get; set; }
}