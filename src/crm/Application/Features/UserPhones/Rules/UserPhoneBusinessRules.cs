using Application.Features.UserPhones.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserPhones.Rules;

public class UserPhoneBusinessRules : BaseBusinessRules
{
    private readonly IUserPhoneRepository _userPhoneRepository;
    private readonly ILocalizationService _localizationService;

    public UserPhoneBusinessRules(IUserPhoneRepository userPhoneRepository, ILocalizationService localizationService)
    {
        _userPhoneRepository = userPhoneRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserPhonesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserPhoneShouldExistWhenSelected(UserPhone? userPhone)
    {
        if (userPhone == null)
            await throwBusinessException(UserPhonesBusinessMessages.UserPhoneNotExists);
    }

    public async Task UserPhoneIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserPhone? userPhone = await _userPhoneRepository.GetAsync(
            predicate: up => up.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserPhoneShouldExistWhenSelected(userPhone);
    }
}