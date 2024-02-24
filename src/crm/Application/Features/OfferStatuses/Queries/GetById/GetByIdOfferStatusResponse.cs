using NArchitecture.Core.Application.Responses;

namespace Application.Features.OfferStatuses.Queries.GetById;

public class GetByIdOfferStatusResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}