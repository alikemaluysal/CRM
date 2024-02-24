using Application.Features.Documents.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Documents;

public class DocumentManager : IDocumentService
{
    private readonly IDocumentRepository _documentRepository;
    private readonly DocumentBusinessRules _documentBusinessRules;

    public DocumentManager(IDocumentRepository documentRepository, DocumentBusinessRules documentBusinessRules)
    {
        _documentRepository = documentRepository;
        _documentBusinessRules = documentBusinessRules;
    }

    public async Task<Document?> GetAsync(
        Expression<Func<Document, bool>> predicate,
        Func<IQueryable<Document>, IIncludableQueryable<Document, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Document? document = await _documentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return document;
    }

    public async Task<IPaginate<Document>?> GetListAsync(
        Expression<Func<Document, bool>>? predicate = null,
        Func<IQueryable<Document>, IOrderedQueryable<Document>>? orderBy = null,
        Func<IQueryable<Document>, IIncludableQueryable<Document, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Document> documentList = await _documentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return documentList;
    }

    public async Task<Document> AddAsync(Document document)
    {
        Document addedDocument = await _documentRepository.AddAsync(document);

        return addedDocument;
    }

    public async Task<Document> UpdateAsync(Document document)
    {
        Document updatedDocument = await _documentRepository.UpdateAsync(document);

        return updatedDocument;
    }

    public async Task<Document> DeleteAsync(Document document, bool permanent = false)
    {
        Document deletedDocument = await _documentRepository.DeleteAsync(document);

        return deletedDocument;
    }
}
