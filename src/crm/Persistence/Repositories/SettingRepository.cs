using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SettingRepository : EfRepositoryBase<Setting, Guid, BaseDbContext>, ISettingRepository
{
    public SettingRepository(BaseDbContext context) : base(context)
    {
    }
}