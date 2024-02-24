using NArchitecture.Core.Application.Responses;

namespace Application.Features.OfferStatuses.Commands.Delete;

public class DeletedOfferStatusResponse : IResponse
{
    public Guid Id { get; set; }
}