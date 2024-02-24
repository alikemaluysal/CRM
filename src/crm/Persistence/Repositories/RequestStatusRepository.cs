using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RequestStatusRepository : EfRepositoryBase<RequestStatus, Guid, BaseDbContext>, IRequestStatusRepository
{
    public RequestStatusRepository(BaseDbContext context) : base(context)
    {
    }
}