using Application.Features.TaskEntities.Constants;
using Application.Features.TaskEntities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.TaskEntities.Constants.TaskEntitiesOperationClaims;

namespace Application.Features.TaskEntities.Commands.Update;

public class UpdateTaskEntityCommand : IRequest<UpdatedTaskEntityResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid RequestId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public DateTime TaskStartDate { get; set; }
    public DateTime TaskEndDate { get; set; }
    public string? Description { get; set; }
    public Guid TaskStatusId { get; set; }

    public string[] Roles => [Admin, Write, TaskEntitiesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTaskEntities"];

    public class UpdateTaskEntityCommandHandler : IRequestHandler<UpdateTaskEntityCommand, UpdatedTaskEntityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskEntityRepository _taskEntityRepository;
        private readonly TaskEntityBusinessRules _taskEntityBusinessRules;

        public UpdateTaskEntityCommandHandler(IMapper mapper, ITaskEntityRepository taskEntityRepository,
                                         TaskEntityBusinessRules taskEntityBusinessRules)
        {
            _mapper = mapper;
            _taskEntityRepository = taskEntityRepository;
            _taskEntityBusinessRules = taskEntityBusinessRules;
        }

        public async Task<UpdatedTaskEntityResponse> Handle(UpdateTaskEntityCommand request, CancellationToken cancellationToken)
        {
            TaskEntity? taskEntity = await _taskEntityRepository.GetAsync(predicate: te => te.Id == request.Id, cancellationToken: cancellationToken);
            await _taskEntityBusinessRules.TaskEntityShouldExistWhenSelected(taskEntity);
            taskEntity = _mapper.Map(request, taskEntity);

            await _taskEntityRepository.UpdateAsync(taskEntity!);

            UpdatedTaskEntityResponse response = _mapper.Map<UpdatedTaskEntityResponse>(taskEntity);
            return response;
        }
    }
}