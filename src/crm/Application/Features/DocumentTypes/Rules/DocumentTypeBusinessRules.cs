using Application.Features.DocumentTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.DocumentTypes.Rules;

public class DocumentTypeBusinessRules : BaseBusinessRules
{
    private readonly IDocumentTypeRepository _documentTypeRepository;
    private readonly ILocalizationService _localizationService;

    public DocumentTypeBusinessRules(IDocumentTypeRepository documentTypeRepository, ILocalizationService localizationService)
    {
        _documentTypeRepository = documentTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DocumentTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DocumentTypeShouldExistWhenSelected(DocumentType? documentType)
    {
        if (documentType == null)
            await throwBusinessException(DocumentTypesBusinessMessages.DocumentTypeNotExists);
    }

    public async Task DocumentTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        DocumentType? documentType = await _documentTypeRepository.GetAsync(
            predicate: dt => dt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DocumentTypeShouldExistWhenSelected(documentType);
    }
}