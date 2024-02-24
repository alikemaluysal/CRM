using Application.Features.DocumentTypes.Constants;
using Application.Features.DocumentTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.DocumentTypes.Constants.DocumentTypesOperationClaims;

namespace Application.Features.DocumentTypes.Commands.Update;

public class UpdateDocumentTypeCommand : IRequest<UpdatedDocumentTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public string[] Roles => [Admin, Write, DocumentTypesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDocumentTypes"];

    public class UpdateDocumentTypeCommandHandler : IRequestHandler<UpdateDocumentTypeCommand, UpdatedDocumentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly DocumentTypeBusinessRules _documentTypeBusinessRules;

        public UpdateDocumentTypeCommandHandler(IMapper mapper, IDocumentTypeRepository documentTypeRepository,
                                         DocumentTypeBusinessRules documentTypeBusinessRules)
        {
            _mapper = mapper;
            _documentTypeRepository = documentTypeRepository;
            _documentTypeBusinessRules = documentTypeBusinessRules;
        }

        public async Task<UpdatedDocumentTypeResponse> Handle(UpdateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            DocumentType? documentType = await _documentTypeRepository.GetAsync(predicate: dt => dt.Id == request.Id, cancellationToken: cancellationToken);
            await _documentTypeBusinessRules.DocumentTypeShouldExistWhenSelected(documentType);
            documentType = _mapper.Map(request, documentType);

            await _documentTypeRepository.UpdateAsync(documentType!);

            UpdatedDocumentTypeResponse response = _mapper.Map<UpdatedDocumentTypeResponse>(documentType);
            return response;
        }
    }
}