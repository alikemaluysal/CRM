using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.UserAddresses.Commands.Update;

public class UpdatedUserAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Description { get; set; }
    public AddressTypeEnum AddressType { get; set; }
}