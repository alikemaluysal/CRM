using Application.Features.Documents.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Documents.Rules;

public class DocumentBusinessRules : BaseBusinessRules
{
    private readonly IDocumentRepository _documentRepository;
    private readonly ILocalizationService _localizationService;

    public DocumentBusinessRules(IDocumentRepository documentRepository, ILocalizationService localizationService)
    {
        _documentRepository = documentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DocumentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DocumentShouldExistWhenSelected(Document? document)
    {
        if (document == null)
            await throwBusinessException(DocumentsBusinessMessages.DocumentNotExists);
    }

    public async Task DocumentIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Document? document = await _documentRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DocumentShouldExistWhenSelected(document);
    }
}