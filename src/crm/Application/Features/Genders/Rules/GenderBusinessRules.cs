using Application.Features.Genders.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Genders.Rules;

public class GenderBusinessRules : BaseBusinessRules
{
    private readonly IGenderRepository _genderRepository;
    private readonly ILocalizationService _localizationService;

    public GenderBusinessRules(IGenderRepository genderRepository, ILocalizationService localizationService)
    {
        _genderRepository = genderRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, GendersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task GenderShouldExistWhenSelected(Gender? gender)
    {
        if (gender == null)
            await throwBusinessException(GendersBusinessMessages.GenderNotExists);
    }

    public async Task GenderIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Gender? gender = await _genderRepository.GetAsync(
            predicate: g => g.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GenderShouldExistWhenSelected(gender);
    }
}