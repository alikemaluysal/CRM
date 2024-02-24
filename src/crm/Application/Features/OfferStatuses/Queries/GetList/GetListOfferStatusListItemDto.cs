using NArchitecture.Core.Application.Dtos;

namespace Application.Features.OfferStatuses.Queries.GetList;

public class GetListOfferStatusListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}