using Application.Features.TaskEntities.Constants;
using Application.Features.TaskEntities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.TaskEntities.Constants.TaskEntitiesOperationClaims;

namespace Application.Features.TaskEntities.Queries.GetById;

public class GetByIdTaskEntityQuery : IRequest<GetByIdTaskEntityResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdTaskEntityQueryHandler : IRequestHandler<GetByIdTaskEntityQuery, GetByIdTaskEntityResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskEntityRepository _taskEntityRepository;
        private readonly TaskEntityBusinessRules _taskEntityBusinessRules;

        public GetByIdTaskEntityQueryHandler(IMapper mapper, ITaskEntityRepository taskEntityRepository, TaskEntityBusinessRules taskEntityBusinessRules)
        {
            _mapper = mapper;
            _taskEntityRepository = taskEntityRepository;
            _taskEntityBusinessRules = taskEntityBusinessRules;
        }

        public async Task<GetByIdTaskEntityResponse> Handle(GetByIdTaskEntityQuery request, CancellationToken cancellationToken)
        {
            TaskEntity? taskEntity = await _taskEntityRepository.GetAsync(predicate: te => te.Id == request.Id, cancellationToken: cancellationToken);
            await _taskEntityBusinessRules.TaskEntityShouldExistWhenSelected(taskEntity);

            GetByIdTaskEntityResponse response = _mapper.Map<GetByIdTaskEntityResponse>(taskEntity);
            return response;
        }
    }
}