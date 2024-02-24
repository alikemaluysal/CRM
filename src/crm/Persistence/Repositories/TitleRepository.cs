using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TitleRepository : EfRepositoryBase<Title, Guid, BaseDbContext>, ITitleRepository
{
    public TitleRepository(BaseDbContext context) : base(context)
    {
    }
}