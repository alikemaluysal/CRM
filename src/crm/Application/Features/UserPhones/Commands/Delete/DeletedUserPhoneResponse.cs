using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserPhones.Commands.Delete;

public class DeletedUserPhoneResponse : IResponse
{
    public Guid Id { get; set; }
}