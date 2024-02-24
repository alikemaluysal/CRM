using Application.Features.Offers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Offers.Rules;

public class OfferBusinessRules : BaseBusinessRules
{
    private readonly IOfferRepository _offerRepository;
    private readonly ILocalizationService _localizationService;

    public OfferBusinessRules(IOfferRepository offerRepository, ILocalizationService localizationService)
    {
        _offerRepository = offerRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, OffersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task OfferShouldExistWhenSelected(Offer? offer)
    {
        if (offer == null)
            await throwBusinessException(OffersBusinessMessages.OfferNotExists);
    }

    public async Task OfferIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Offer? offer = await _offerRepository.GetAsync(
            predicate: o => o.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OfferShouldExistWhenSelected(offer);
    }
}