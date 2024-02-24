using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserPhoneRepository : IAsyncRepository<UserPhone, Guid>, IRepository<UserPhone, Guid>
{
}