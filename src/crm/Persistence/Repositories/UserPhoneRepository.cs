using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserPhoneRepository : EfRepositoryBase<UserPhone, Guid, BaseDbContext>, IUserPhoneRepository
{
    public UserPhoneRepository(BaseDbContext context) : base(context)
    {
    }
}