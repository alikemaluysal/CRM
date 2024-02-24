using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRequestStatusRepository : IAsyncRepository<RequestStatus, Guid>, IRepository<RequestStatus, Guid>
{
}