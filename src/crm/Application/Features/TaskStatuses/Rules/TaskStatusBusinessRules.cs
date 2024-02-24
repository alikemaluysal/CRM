using Application.Features.TaskStatuses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Application.Features.TaskStatuses.Rules;

public class TaskStatusBusinessRules : BaseBusinessRules
{
    private readonly ITaskStatusRepository _taskStatusRepository;
    private readonly ILocalizationService _localizationService;

    public TaskStatusBusinessRules(ITaskStatusRepository taskStatusRepository, ILocalizationService localizationService)
    {
        _taskStatusRepository = taskStatusRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TaskStatusBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TaskStatusShouldExistWhenSelected(TaskStatus? taskStatus)
    {
        if (taskStatus == null)
            await throwBusinessException(TaskStatusBusinessMessages.TaskStatusNotExists);
    }

    public async Task TaskStatusIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        TaskStatus? taskStatus = await _taskStatusRepository.GetAsync(
            predicate: ts => ts.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TaskStatusShouldExistWhenSelected(taskStatus);
    }
}