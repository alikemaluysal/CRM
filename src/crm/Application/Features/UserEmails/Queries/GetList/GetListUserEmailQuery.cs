using Application.Features.UserEmails.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.UserEmails.Constants.UserEmailsOperationClaims;

namespace Application.Features.UserEmails.Queries.GetList;

public class GetListUserEmailQuery : IRequest<GetListResponse<GetListUserEmailListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListUserEmails({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetUserEmails";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListUserEmailQueryHandler : IRequestHandler<GetListUserEmailQuery, GetListResponse<GetListUserEmailListItemDto>>
    {
        private readonly IUserEmailRepository _userEmailRepository;
        private readonly IMapper _mapper;

        public GetListUserEmailQueryHandler(IUserEmailRepository userEmailRepository, IMapper mapper)
        {
            _userEmailRepository = userEmailRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserEmailListItemDto>> Handle(GetListUserEmailQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserEmail> userEmails = await _userEmailRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserEmailListItemDto> response = _mapper.Map<GetListResponse<GetListUserEmailListItemDto>>(userEmails);
            return response;
        }
    }
}