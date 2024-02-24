using Application.Features.Regions.Constants;
using Application.Features.Regions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Regions.Constants.RegionsOperationClaims;

namespace Application.Features.Regions.Commands.Create;

public class CreateRegionCommand : IRequest<CreatedRegionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; }

    public string[] Roles => [Admin, Write, RegionsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRegions"];

    public class CreateRegionCommandHandler : IRequestHandler<CreateRegionCommand, CreatedRegionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;
        private readonly RegionBusinessRules _regionBusinessRules;

        public CreateRegionCommandHandler(IMapper mapper, IRegionRepository regionRepository,
                                         RegionBusinessRules regionBusinessRules)
        {
            _mapper = mapper;
            _regionRepository = regionRepository;
            _regionBusinessRules = regionBusinessRules;
        }

        public async Task<CreatedRegionResponse> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
        {
            Region region = _mapper.Map<Region>(request);

            await _regionRepository.AddAsync(region);

            CreatedRegionResponse response = _mapper.Map<CreatedRegionResponse>(region);
            return response;
        }
    }
}