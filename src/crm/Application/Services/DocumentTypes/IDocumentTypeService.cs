using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DocumentTypes;

public interface IDocumentTypeService
{
    Task<DocumentType?> GetAsync(
        Expression<Func<DocumentType, bool>> predicate,
        Func<IQueryable<DocumentType>, IIncludableQueryable<DocumentType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<DocumentType>?> GetListAsync(
        Expression<Func<DocumentType, bool>>? predicate = null,
        Func<IQueryable<DocumentType>, IOrderedQueryable<DocumentType>>? orderBy = null,
        Func<IQueryable<DocumentType>, IIncludableQueryable<DocumentType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<DocumentType> AddAsync(DocumentType documentType);
    Task<DocumentType> UpdateAsync(DocumentType documentType);
    Task<DocumentType> DeleteAsync(DocumentType documentType, bool permanent = false);
}
