using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Documents;

public interface IDocumentService
{
    Task<Document?> GetAsync(
        Expression<Func<Document, bool>> predicate,
        Func<IQueryable<Document>, IIncludableQueryable<Document, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Document>?> GetListAsync(
        Expression<Func<Document, bool>>? predicate = null,
        Func<IQueryable<Document>, IOrderedQueryable<Document>>? orderBy = null,
        Func<IQueryable<Document>, IIncludableQueryable<Document, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Document> AddAsync(Document document);
    Task<Document> UpdateAsync(Document document);
    Task<Document> DeleteAsync(Document document, bool permanent = false);
}
