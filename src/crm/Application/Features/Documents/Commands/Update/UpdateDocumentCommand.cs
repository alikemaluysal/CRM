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

namespace Application.Features.Documents.Commands.Update;

public class UpdateDocumentCommand : IRequest<UpdatedDocumentResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid RequestId { get; set; }
    public string DocumentFileName { get; set; }
    public Guid DocumentTypeId { get; set; }

    public string[] Roles => [Admin, Write, DocumentsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetDocuments"];

    public class UpdateDocumentCommandHandler : IRequestHandler<UpdateDocumentCommand, UpdatedDocumentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentRepository _documentRepository;
        private readonly DocumentBusinessRules _documentBusinessRules;

        public UpdateDocumentCommandHandler(IMapper mapper, IDocumentRepository documentRepository,
                                         DocumentBusinessRules documentBusinessRules)
        {
            _mapper = mapper;
            _documentRepository = documentRepository;
            _documentBusinessRules = documentBusinessRules;
        }

        public async Task<UpdatedDocumentResponse> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            Document? document = await _documentRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _documentBusinessRules.DocumentShouldExistWhenSelected(document);
            document = _mapper.Map(request, document);

            await _documentRepository.UpdateAsync(document!);

            UpdatedDocumentResponse response = _mapper.Map<UpdatedDocumentResponse>(document);
            return response;
        }
    }
}