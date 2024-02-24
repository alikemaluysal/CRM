using Application.Features.Settings.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Settings.Rules;

public class SettingBusinessRules : BaseBusinessRules
{
    private readonly ISettingRepository _settingRepository;
    private readonly ILocalizationService _localizationService;

    public SettingBusinessRules(ISettingRepository settingRepository, ILocalizationService localizationService)
    {
        _settingRepository = settingRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SettingsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SettingShouldExistWhenSelected(Setting? setting)
    {
        if (setting == null)
            await throwBusinessException(SettingsBusinessMessages.SettingNotExists);
    }

    public async Task SettingIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Setting? setting = await _settingRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SettingShouldExistWhenSelected(setting);
    }
}