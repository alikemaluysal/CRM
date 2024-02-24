using Application.Features.TaskStatuses.Constants;
using Application.Features.TaskStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.TaskStatuses.Constants.TaskStatusOperationClaims;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Application.Features.TaskStatuses.Commands.Create;

public class CreateTaskStatusCommand : IRequest<CreatedTaskStatusResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string? Name { get; set; }

    public string[] Roles => [Admin, Write, TaskStatusOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTaskStatus"];

    public class CreateTaskStatusCommandHandler : IRequestHandler<CreateTaskStatusCommand, CreatedTaskStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskStatusRepository _taskStatusRepository;
        private readonly TaskStatusBusinessRules _taskStatusBusinessRules;

        public CreateTaskStatusCommandHandler(IMapper mapper, ITaskStatusRepository taskStatusRepository,
                                         TaskStatusBusinessRules taskStatusBusinessRules)
        {
            _mapper = mapper;
            _taskStatusRepository = taskStatusRepository;
            _taskStatusBusinessRules = taskStatusBusinessRules;
        }

        public async Task<CreatedTaskStatusResponse> Handle(CreateTaskStatusCommand request, CancellationToken cancellationToken)
        {
            TaskStatus taskStatus = _mapper.Map<TaskStatus>(request);

            await _taskStatusRepository.AddAsync(taskStatus);

            CreatedTaskStatusResponse response = _mapper.Map<CreatedTaskStatusResponse>(taskStatus);
            return response;
        }
    }
}