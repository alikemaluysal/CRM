using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserEmailRepository : IAsyncRepository<UserEmail, Guid>, IRepository<UserEmail, Guid>
{
}