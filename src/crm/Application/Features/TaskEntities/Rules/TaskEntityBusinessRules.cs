using Application.Features.TaskEntities.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.TaskEntities.Rules;

public class TaskEntityBusinessRules : BaseBusinessRules
{
    private readonly ITaskEntityRepository _taskEntityRepository;
    private readonly ILocalizationService _localizationService;

    public TaskEntityBusinessRules(ITaskEntityRepository taskEntityRepository, ILocalizationService localizationService)
    {
        _taskEntityRepository = taskEntityRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TaskEntitiesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TaskEntityShouldExistWhenSelected(TaskEntity? taskEntity)
    {
        if (taskEntity == null)
            await throwBusinessException(TaskEntitiesBusinessMessages.TaskEntityNotExists);
    }

    public async Task TaskEntityIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        TaskEntity? taskEntity = await _taskEntityRepository.GetAsync(
            predicate: te => te.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TaskEntityShouldExistWhenSelected(taskEntity);
    }
}