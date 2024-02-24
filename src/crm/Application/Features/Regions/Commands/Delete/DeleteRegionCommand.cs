using Application.Features.Regions.Constants;
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

namespace Application.Features.Regions.Commands.Delete;

public class DeleteRegionCommand : IRequest<DeletedRegionResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, RegionsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRegions"];

    public class DeleteRegionCommandHandler : IRequestHandler<DeleteRegionCommand, DeletedRegionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRegionRepository _regionRepository;
        private readonly RegionBusinessRules _regionBusinessRules;

        public DeleteRegionCommandHandler(IMapper mapper, IRegionRepository regionRepository,
                                         RegionBusinessRules regionBusinessRules)
        {
            _mapper = mapper;
            _regionRepository = regionRepository;
            _regionBusinessRules = regionBusinessRules;
        }

        public async Task<DeletedRegionResponse> Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
        {
            Region? region = await _regionRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _regionBusinessRules.RegionShouldExistWhenSelected(region);

            await _regionRepository.DeleteAsync(region!);

            DeletedRegionResponse response = _mapper.Map<DeletedRegionResponse>(region);
            return response;
        }
    }
}