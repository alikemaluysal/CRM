using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StatusTypeRepository : EfRepositoryBase<StatusType, Guid, BaseDbContext>, IStatusTypeRepository
{
    public StatusTypeRepository(BaseDbContext context) : base(context)
    {
    }
}