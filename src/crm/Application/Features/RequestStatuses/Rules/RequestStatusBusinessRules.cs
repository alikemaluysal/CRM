using Application.Features.RequestStatuses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.RequestStatuses.Rules;

public class RequestStatusBusinessRules : BaseBusinessRules
{
    private readonly IRequestStatusRepository _requestStatusRepository;
    private readonly ILocalizationService _localizationService;

    public RequestStatusBusinessRules(IRequestStatusRepository requestStatusRepository, ILocalizationService localizationService)
    {
        _requestStatusRepository = requestStatusRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RequestStatusBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RequestStatusShouldExistWhenSelected(RequestStatus? requestStatus)
    {
        if (requestStatus == null)
            await throwBusinessException(RequestStatusBusinessMessages.RequestStatusNotExists);
    }

    public async Task RequestStatusIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        RequestStatus? requestStatus = await _requestStatusRepository.GetAsync(
            predicate: rs => rs.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RequestStatusShouldExistWhenSelected(requestStatus);
    }
}