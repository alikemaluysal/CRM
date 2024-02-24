using Application.Features.OfferStatuses.Constants;
using Application.Features.OfferStatuses.Constants;
using Application.Features.OfferStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.OfferStatuses.Constants.OfferStatusOperationClaims;

namespace Application.Features.OfferStatuses.Commands.Delete;

public class DeleteOfferStatusCommand : IRequest<DeletedOfferStatusResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, OfferStatusOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOfferStatus"];

    public class DeleteOfferStatusCommandHandler : IRequestHandler<DeleteOfferStatusCommand, DeletedOfferStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferStatusRepository _offerStatusRepository;
        private readonly OfferStatusBusinessRules _offerStatusBusinessRules;

        public DeleteOfferStatusCommandHandler(IMapper mapper, IOfferStatusRepository offerStatusRepository,
                                         OfferStatusBusinessRules offerStatusBusinessRules)
        {
            _mapper = mapper;
            _offerStatusRepository = offerStatusRepository;
            _offerStatusBusinessRules = offerStatusBusinessRules;
        }

        public async Task<DeletedOfferStatusResponse> Handle(DeleteOfferStatusCommand request, CancellationToken cancellationToken)
        {
            OfferStatus? offerStatus = await _offerStatusRepository.GetAsync(predicate: os => os.Id == request.Id, cancellationToken: cancellationToken);
            await _offerStatusBusinessRules.OfferStatusShouldExistWhenSelected(offerStatus);

            await _offerStatusRepository.DeleteAsync(offerStatus!);

            DeletedOfferStatusResponse response = _mapper.Map<DeletedOfferStatusResponse>(offerStatus);
            return response;
        }
    }
}