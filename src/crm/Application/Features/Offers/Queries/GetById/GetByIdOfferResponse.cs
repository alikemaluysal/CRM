using NArchitecture.Core.Application.Responses;

namespace Application.Features.Offers.Queries.GetById;

public class GetByIdOfferResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid RequestId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public DateTime? OfferDate { get; set; }
    public decimal BidAmount { get; set; }
    public Guid OfferStatusId { get; set; }
}