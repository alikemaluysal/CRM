using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.UserAddresses.Commands.Create;

public class CreatedUserAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Description { get; set; }
    public AddressTypeEnum AddressType { get; set; }
}