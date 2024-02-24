using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDocumentRepository : IAsyncRepository<Document, Guid>, IRepository<Document, Guid>
{
}