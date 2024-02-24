using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GenderRepository : EfRepositoryBase<Gender, Guid, BaseDbContext>, IGenderRepository
{
    public GenderRepository(BaseDbContext context) : base(context)
    {
    }
}