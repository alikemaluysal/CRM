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

namespace Application.Features.DocumentTypes.Commands.Create;

public class CreateDocumentTypeCommand : IRequest<CreatedDocumentTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string? Name { get; set; }

    public string[] Roles => [Admin, Write, DocumentTypesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDocumentTypes"];

    public class CreateDocumentTypeCommandHandler : IRequestHandler<CreateDocumentTypeCommand, CreatedDocumentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly DocumentTypeBusinessRules _documentTypeBusinessRules;

        public CreateDocumentTypeCommandHandler(IMapper mapper, IDocumentTypeRepository documentTypeRepository,
                                         DocumentTypeBusinessRules documentTypeBusinessRules)
        {
            _mapper = mapper;
            _documentTypeRepository = documentTypeRepository;
            _documentTypeBusinessRules = documentTypeBusinessRules;
        }

        public async Task<CreatedDocumentTypeResponse> Handle(CreateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            DocumentType documentType = _mapper.Map<DocumentType>(request);

            await _documentTypeRepository.AddAsync(documentType);

            CreatedDocumentTypeResponse response = _mapper.Map<CreatedDocumentTypeResponse>(documentType);
            return response;
        }
    }
}