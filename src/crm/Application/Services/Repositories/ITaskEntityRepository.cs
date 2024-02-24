using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITaskEntityRepository : IAsyncRepository<TaskEntity, Guid>, IRepository<TaskEntity, Guid>
{
}