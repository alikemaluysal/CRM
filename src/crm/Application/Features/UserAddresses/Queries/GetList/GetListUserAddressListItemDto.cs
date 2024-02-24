using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.UserAddresses.Queries.GetList;

public class GetListUserAddressListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Description { get; set; }
    public AddressTypeEnum AddressType { get; set; }
}