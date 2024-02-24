using Application.Features.DocumentTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DocumentTypes;

public class DocumentTypeManager : IDocumentTypeService
{
    private readonly IDocumentTypeRepository _documentTypeRepository;
    private readonly DocumentTypeBusinessRules _documentTypeBusinessRules;

    public DocumentTypeManager(IDocumentTypeRepository documentTypeRepository, DocumentTypeBusinessRules documentTypeBusinessRules)
    {
        _documentTypeRepository = documentTypeRepository;
        _documentTypeBusinessRules = documentTypeBusinessRules;
    }

    public async Task<DocumentType?> GetAsync(
        Expression<Func<DocumentType, bool>> predicate,
        Func<IQueryable<DocumentType>, IIncludableQueryable<DocumentType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        DocumentType? documentType = await _documentTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return documentType;
    }

    public async Task<IPaginate<DocumentType>?> GetListAsync(
        Expression<Func<DocumentType, bool>>? predicate = null,
        Func<IQueryable<DocumentType>, IOrderedQueryable<DocumentType>>? orderBy = null,
        Func<IQueryable<DocumentType>, IIncludableQueryable<DocumentType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<DocumentType> documentTypeList = await _documentTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return documentTypeList;
    }

    public async Task<DocumentType> AddAsync(DocumentType documentType)
    {
        DocumentType addedDocumentType = await _documentTypeRepository.AddAsync(documentType);

        return addedDocumentType;
    }

    public async Task<DocumentType> UpdateAsync(DocumentType documentType)
    {
        DocumentType updatedDocumentType = await _documentTypeRepository.UpdateAsync(documentType);

        return updatedDocumentType;
    }

    public async Task<DocumentType> DeleteAsync(DocumentType documentType, bool permanent = false)
    {
        DocumentType deletedDocumentType = await _documentTypeRepository.DeleteAsync(documentType);

        return deletedDocumentType;
    }
}
