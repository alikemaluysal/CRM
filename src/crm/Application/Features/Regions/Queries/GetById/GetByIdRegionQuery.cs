using Application.Features.Regions.Constants;
using Application.Features.Regions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Regions.Constants.RegionsOperationClaims;

namespace Application.Features.Regions.Queries.GetById;

public class GetByIdRegionQuery : IRequest<GetByIdRegionResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdRegionQueryHandler : IRequestHandler<GetByIdRegionQuery, GetByIdRegionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;
        private readonly RegionBusinessRules _regionBusinessRules;

        public GetByIdRegionQueryHandler(IMapper mapper, IRegionRepository regionRepository, RegionBusinessRules regionBusinessRules)
        {
            _mapper = mapper;
            _regionRepository = regionRepository;
            _regionBusinessRules = regionBusinessRules;
        }

        public async Task<GetByIdRegionResponse> Handle(GetByIdRegionQuery request, CancellationToken cancellationToken)
        {
            Region? region = await _regionRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _regionBusinessRules.RegionShouldExistWhenSelected(region);

            GetByIdRegionResponse response = _mapper.Map<GetByIdRegionResponse>(region);
            return response;
        }
    }
}