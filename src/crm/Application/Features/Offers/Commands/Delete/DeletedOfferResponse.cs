using NArchitecture.Core.Application.Responses;

namespace Application.Features.Offers.Commands.Delete;

public class DeletedOfferResponse : IResponse
{
    public Guid Id { get; set; }
}