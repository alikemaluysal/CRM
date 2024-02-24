using Application.Features.Requests.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Requests.Rules;

public class RequestBusinessRules : BaseBusinessRules
{
    private readonly IRequestRepository _requestRepository;
    private readonly ILocalizationService _localizationService;

    public RequestBusinessRules(IRequestRepository requestRepository, ILocalizationService localizationService)
    {
        _requestRepository = requestRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RequestsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RequestShouldExistWhenSelected(Request? request)
    {
        if (request == null)
            await throwBusinessException(RequestsBusinessMessages.RequestNotExists);
    }

    public async Task RequestIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Request? request = await _requestRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RequestShouldExistWhenSelected(request);
    }
}