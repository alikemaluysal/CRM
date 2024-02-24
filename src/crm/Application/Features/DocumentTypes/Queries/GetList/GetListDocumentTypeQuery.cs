using Application.Features.DocumentTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.DocumentTypes.Constants.DocumentTypesOperationClaims;

namespace Application.Features.DocumentTypes.Queries.GetList;

public class GetListDocumentTypeQuery : IRequest<GetListResponse<GetListDocumentTypeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListDocumentTypes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetDocumentTypes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListDocumentTypeQueryHandler : IRequestHandler<GetListDocumentTypeQuery, GetListResponse<GetListDocumentTypeListItemDto>>
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IMapper _mapper;

        public GetListDocumentTypeQueryHandler(IDocumentTypeRepository documentTypeRepository, IMapper mapper)
        {
            _documentTypeRepository = documentTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDocumentTypeListItemDto>> Handle(GetListDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<DocumentType> documentTypes = await _documentTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDocumentTypeListItemDto> response = _mapper.Map<GetListResponse<GetListDocumentTypeListItemDto>>(documentTypes);
            return response;
        }
    }
}