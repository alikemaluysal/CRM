using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserEmailRepository : EfRepositoryBase<UserEmail, Guid, BaseDbContext>, IUserEmailRepository
{
    public UserEmailRepository(BaseDbContext context) : base(context)
    {
    }
}