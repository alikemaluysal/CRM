using Application.Features.Documents.Constants;
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

namespace Application.Features.Documents.Commands.Delete;

public class DeleteDocumentCommand : IRequest<DeletedDocumentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, DocumentsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDocuments"];

    public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand, DeletedDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;
        private readonly DocumentBusinessRules _documentBusinessRules;

        public DeleteDocumentCommandHandler(IMapper mapper, IDocumentRepository documentRepository,
                                         DocumentBusinessRules documentBusinessRules)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
            _documentBusinessRules = documentBusinessRules;
        }

        public async Task<DeletedDocumentResponse> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            Document? document = await _documentRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _documentBusinessRules.DocumentShouldExistWhenSelected(document);

            await _documentRepository.DeleteAsync(document!);

            DeletedDocumentResponse response = _mapper.Map<DeletedDocumentResponse>(document);
            return response;
        }
    }
}