using Application.Features.DocumentTypes.Constants;
using Application.Features.DocumentTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.DocumentTypes.Constants.DocumentTypesOperationClaims;

namespace Application.Features.DocumentTypes.Queries.GetById;

public class GetByIdDocumentTypeQuery : IRequest<GetByIdDocumentTypeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdDocumentTypeQueryHandler : IRequestHandler<GetByIdDocumentTypeQuery, GetByIdDocumentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly DocumentTypeBusinessRules _documentTypeBusinessRules;

        public GetByIdDocumentTypeQueryHandler(IMapper mapper, IDocumentTypeRepository documentTypeRepository, DocumentTypeBusinessRules documentTypeBusinessRules)
        {
            _mapper = mapper;
            _documentTypeRepository = documentTypeRepository;
            _documentTypeBusinessRules = documentTypeBusinessRules;
        }

        public async Task<GetByIdDocumentTypeResponse> Handle(GetByIdDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            DocumentType? documentType = await _documentTypeRepository.GetAsync(predicate: dt => dt.Id == request.Id, cancellationToken: cancellationToken);
            await _documentTypeBusinessRules.DocumentTypeShouldExistWhenSelected(documentType);

            GetByIdDocumentTypeResponse response = _mapper.Map<GetByIdDocumentTypeResponse>(documentType);
            return response;
        }
    }
}