using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Offers.Queries.GetList;

public class GetListOfferListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid RequestId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public DateTime? OfferDate { get; set; }
    public decimal BidAmount { get; set; }
    public Guid OfferStatusId { get; set; }
}