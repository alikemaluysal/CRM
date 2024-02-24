using Application.Features.OfferStatuses.Constants;
using Application.Features.OfferStatuses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.OfferStatuses.Constants.OfferStatusOperationClaims;

namespace Application.Features.OfferStatuses.Queries.GetById;

public class GetByIdOfferStatusQuery : IRequest<GetByIdOfferStatusResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdOfferStatusQueryHandler : IRequestHandler<GetByIdOfferStatusQuery, GetByIdOfferStatusResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOfferStatusRepository _offerStatusRepository;
        private readonly OfferStatusBusinessRules _offerStatusBusinessRules;

        public GetByIdOfferStatusQueryHandler(IMapper mapper, IOfferStatusRepository offerStatusRepository, OfferStatusBusinessRules offerStatusBusinessRules)
        {
            _mapper = mapper;
            _offerStatusRepository = offerStatusRepository;
            _offerStatusBusinessRules = offerStatusBusinessRules;
        }

        public async Task<GetByIdOfferStatusResponse> Handle(GetByIdOfferStatusQuery request, CancellationToken cancellationToken)
        {
            OfferStatus? offerStatus = await _offerStatusRepository.GetAsync(predicate: os => os.Id == request.Id, cancellationToken: cancellationToken);
            await _offerStatusBusinessRules.OfferStatusShouldExistWhenSelected(offerStatus);

            GetByIdOfferStatusResponse response = _mapper.Map<GetByIdOfferStatusResponse>(offerStatus);
            return response;
        }
    }
}