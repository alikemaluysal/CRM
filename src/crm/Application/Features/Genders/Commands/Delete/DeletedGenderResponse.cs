using NArchitecture.Core.Application.Responses;

namespace Application.Features.Genders.Commands.Delete;

public class DeletedGenderResponse : IResponse
{
    public Guid Id { get; set; }
}