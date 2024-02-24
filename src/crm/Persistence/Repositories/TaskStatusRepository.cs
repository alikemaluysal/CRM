using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Persistence.Repositories;

public class TaskStatusRepository : EfRepositoryBase<TaskStatus, Guid, BaseDbContext>, ITaskStatusRepository
{
    public TaskStatusRepository(BaseDbContext context) : base(context)
    {
    }
}