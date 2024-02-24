using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRequestRepository : IAsyncRepository<Request, Guid>, IRepository<Request, Guid>
{
}