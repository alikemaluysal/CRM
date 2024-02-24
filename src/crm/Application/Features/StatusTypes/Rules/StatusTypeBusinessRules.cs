using Application.Features.StatusTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.StatusTypes.Rules;

public class StatusTypeBusinessRules : BaseBusinessRules
{
    private readonly IStatusTypeRepository _statusTypeRepository;
    private readonly ILocalizationService _localizationService;

    public StatusTypeBusinessRules(IStatusTypeRepository statusTypeRepository, ILocalizationService localizationService)
    {
        _statusTypeRepository = statusTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, StatusTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task StatusTypeShouldExistWhenSelected(StatusType? statusType)
    {
        if (statusType == null)
            await throwBusinessException(StatusTypesBusinessMessages.StatusTypeNotExists);
    }

    public async Task StatusTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StatusType? statusType = await _statusTypeRepository.GetAsync(
            predicate: st => st.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StatusTypeShouldExistWhenSelected(statusType);
    }
}