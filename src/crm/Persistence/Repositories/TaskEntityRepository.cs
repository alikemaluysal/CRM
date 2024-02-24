using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TaskEntityRepository : EfRepositoryBase<TaskEntity, Guid, BaseDbContext>, ITaskEntityRepository
{
    public TaskEntityRepository(BaseDbContext context) : base(context)
    {
    }
}