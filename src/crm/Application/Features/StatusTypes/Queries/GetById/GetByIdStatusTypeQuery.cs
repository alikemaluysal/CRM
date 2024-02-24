using Application.Features.StatusTypes.Constants;
using Application.Features.StatusTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.StatusTypes.Constants.StatusTypesOperationClaims;

namespace Application.Features.StatusTypes.Queries.GetById;

public class GetByIdStatusTypeQuery : IRequest<GetByIdStatusTypeResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdStatusTypeQueryHandler : IRequestHandler<GetByIdStatusTypeQuery, GetByIdStatusTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStatusTypeRepository _statusTypeRepository;
        private readonly StatusTypeBusinessRules _statusTypeBusinessRules;

        public GetByIdStatusTypeQueryHandler(IMapper mapper, IStatusTypeRepository statusTypeRepository, StatusTypeBusinessRules statusTypeBusinessRules)
        {
            _mapper = mapper;
            _statusTypeRepository = statusTypeRepository;
            _statusTypeBusinessRules = statusTypeBusinessRules;
        }

        public async Task<GetByIdStatusTypeResponse> Handle(GetByIdStatusTypeQuery request, CancellationToken cancellationToken)
        {
            StatusType? statusType = await _statusTypeRepository.GetAsync(predicate: st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _statusTypeBusinessRules.StatusTypeShouldExistWhenSelected(statusType);

            GetByIdStatusTypeResponse response = _mapper.Map<GetByIdStatusTypeResponse>(statusType);
            return response;
        }
    }
}