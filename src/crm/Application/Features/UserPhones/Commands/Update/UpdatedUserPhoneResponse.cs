using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.UserPhones.Commands.Update;

public class UpdatedUserPhoneResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? PhoneNumber { get; set; }
    public PhoneTypeEnum PhoneType { get; set; }
}