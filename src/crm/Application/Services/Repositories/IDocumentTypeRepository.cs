using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDocumentTypeRepository : IAsyncRepository<DocumentType, Guid>, IRepository<DocumentType, Guid>
{
}