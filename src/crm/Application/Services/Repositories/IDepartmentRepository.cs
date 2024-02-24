using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDepartmentRepository : IAsyncRepository<Department, Guid>, IRepository<Department, Guid>
{
}