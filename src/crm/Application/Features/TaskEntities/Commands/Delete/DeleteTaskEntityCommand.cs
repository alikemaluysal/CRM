using Application.Features.TaskEntities.Constants;
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

namespace Application.Features.TaskEntities.Commands.Delete;

public class DeleteTaskEntityCommand : IRequest<DeletedTaskEntityResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, TaskEntitiesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTaskEntities"];

    public class DeleteTaskEntityCommandHandler : IRequestHandler<DeleteTaskEntityCommand, DeletedTaskEntityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskEntityRepository _taskEntityRepository;
        private readonly TaskEntityBusinessRules _taskEntityBusinessRules;

        public DeleteTaskEntityCommandHandler(IMapper mapper, ITaskEntityRepository taskEntityRepository,
                                         TaskEntityBusinessRules taskEntityBusinessRules)
        {
            _mapper = mapper;
            _taskEntityRepository = taskEntityRepository;
            _taskEntityBusinessRules = taskEntityBusinessRules;
        }

        public async Task<DeletedTaskEntityResponse> Handle(DeleteTaskEntityCommand request, CancellationToken cancellationToken)
        {
            TaskEntity? taskEntity = await _taskEntityRepository.GetAsync(predicate: te => te.Id == request.Id, cancellationToken: cancellationToken);
            await _taskEntityBusinessRules.TaskEntityShouldExistWhenSelected(taskEntity);

            await _taskEntityRepository.DeleteAsync(taskEntity!);

            DeletedTaskEntityResponse response = _mapper.Map<DeletedTaskEntityResponse>(taskEntity);
            return response;
        }
    }
}