using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DocumentRepository : EfRepositoryBase<Document, Guid, BaseDbContext>, IDocumentRepository
{
    public DocumentRepository(BaseDbContext context) : base(context)
    {
    }
}