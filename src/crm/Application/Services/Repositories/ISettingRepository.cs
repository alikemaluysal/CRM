using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISettingRepository : IAsyncRepository<Setting, Guid>, IRepository<Setting, Guid>
{
}