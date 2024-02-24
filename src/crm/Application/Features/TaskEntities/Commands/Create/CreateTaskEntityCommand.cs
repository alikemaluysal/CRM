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

namespace Application.Features.TaskEntities.Commands.Create;

public class CreateTaskEntityCommand : IRequest<CreatedTaskEntityResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid RequestId { get; set; }
    public Guid EmployeeUserId { get; set; }
    public DateTime TaskStartDate { get; set; }
    public DateTime TaskEndDate { get; set; }
    public string? Description { get; set; }
    public Guid TaskStatusId { get; set; }

    public string[] Roles => [Admin, Write, TaskEntitiesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTaskEntities"];

    public class CreateTaskEntityCommandHandler : IRequestHandler<CreateTaskEntityCommand, CreatedTaskEntityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskEntityRepository _taskEntityRepository;
        private readonly TaskEntityBusinessRules _taskEntityBusinessRules;

        public CreateTaskEntityCommandHandler(IMapper mapper, ITaskEntityRepository taskEntityRepository,
                                         TaskEntityBusinessRules taskEntityBusinessRules)
        {
            _mapper = mapper;
            _taskEntityRepository = taskEntityRepository;
            _taskEntityBusinessRules = taskEntityBusinessRules;
        }

        public async Task<CreatedTaskEntityResponse> Handle(CreateTaskEntityCommand request, CancellationToken cancellationToken)
        {
            TaskEntity taskEntity = _mapper.Map<TaskEntity>(request);

            await _taskEntityRepository.AddAsync(taskEntity);

            CreatedTaskEntityResponse response = _mapper.Map<CreatedTaskEntityResponse>(taskEntity);
            return response;
        }
    }
}