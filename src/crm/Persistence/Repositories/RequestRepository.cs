using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RequestRepository : EfRepositoryBase<Request, Guid, BaseDbContext>, IRequestRepository
{
    public RequestRepository(BaseDbContext context) : base(context)
    {
    }
}