using Application.Features.Documents.Constants;
using Application.Features.Documents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Documents.Constants.DocumentsOperationClaims;

namespace Application.Features.Documents.Commands.Create;

public class CreateDocumentCommand : IRequest<CreatedDocumentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public Guid RequestId { get; set; }
    public string DocumentFileName { get; set; }
    public Guid DocumentTypeId { get; set; }

    public string[] Roles => [Admin, Write, DocumentsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDocuments"];

    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, CreatedDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;
        private readonly DocumentBusinessRules _documentBusinessRules;

        public CreateDocumentCommandHandler(IMapper mapper, IDocumentRepository documentRepository,
                                         DocumentBusinessRules documentBusinessRules)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
            _documentBusinessRules = documentBusinessRules;
        }

        public async Task<CreatedDocumentResponse> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            Document document = _mapper.Map<Document>(request);

            await _documentRepository.AddAsync(document);

            CreatedDocumentResponse response = _mapper.Map<CreatedDocumentResponse>(document);
            return response;
        }
    }
}