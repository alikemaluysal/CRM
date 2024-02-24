using Application.Features.UserEmails.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserEmails.Rules;

public class UserEmailBusinessRules : BaseBusinessRules
{
    private readonly IUserEmailRepository _userEmailRepository;
    private readonly ILocalizationService _localizationService;

    public UserEmailBusinessRules(IUserEmailRepository userEmailRepository, ILocalizationService localizationService)
    {
        _userEmailRepository = userEmailRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserEmailsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserEmailShouldExistWhenSelected(UserEmail? userEmail)
    {
        if (userEmail == null)
            await throwBusinessException(UserEmailsBusinessMessages.UserEmailNotExists);
    }

    public async Task UserEmailIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserEmail? userEmail = await _userEmailRepository.GetAsync(
            predicate: ue => ue.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserEmailShouldExistWhenSelected(userEmail);
    }
}