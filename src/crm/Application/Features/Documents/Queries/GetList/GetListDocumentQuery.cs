using Application.Features.Documents.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Documents.Constants.DocumentsOperationClaims;

namespace Application.Features.Documents.Queries.GetList;

public class GetListDocumentQuery : IRequest<GetListResponse<GetListDocumentListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListDocuments({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetDocuments";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListDocumentQueryHandler : IRequestHandler<GetListDocumentQuery, GetListResponse<GetListDocumentListItemDto>>
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;

        public GetListDocumentQueryHandler(IDocumentRepository documentRepository, IMapper mapper)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDocumentListItemDto>> Handle(GetListDocumentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Document> documents = await _documentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDocumentListItemDto> response = _mapper.Map<GetListResponse<GetListDocumentListItemDto>>(documents);
            return response;
        }
    }
}