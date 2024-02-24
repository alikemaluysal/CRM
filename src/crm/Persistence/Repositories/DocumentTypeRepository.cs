using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DocumentTypeRepository : EfRepositoryBase<DocumentType, Guid, BaseDbContext>, IDocumentTypeRepository
{
    public DocumentTypeRepository(BaseDbContext context) : base(context)
    {
    }
}