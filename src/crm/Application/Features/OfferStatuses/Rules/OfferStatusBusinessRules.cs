using Application.Features.OfferStatuses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.OfferStatuses.Rules;

public class OfferStatusBusinessRules : BaseBusinessRules
{
    private readonly IOfferStatusRepository _offerStatusRepository;
    private readonly ILocalizationService _localizationService;

    public OfferStatusBusinessRules(IOfferStatusRepository offerStatusRepository, ILocalizationService localizationService)
    {
        _offerStatusRepository = offerStatusRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, OfferStatusBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task OfferStatusShouldExistWhenSelected(OfferStatus? offerStatus)
    {
        if (offerStatus == null)
            await throwBusinessException(OfferStatusBusinessMessages.OfferStatusNotExists);
    }

    public async Task OfferStatusIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        OfferStatus? offerStatus = await _offerStatusRepository.GetAsync(
            predicate: os => os.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OfferStatusShouldExistWhenSelected(offerStatus);
    }
}