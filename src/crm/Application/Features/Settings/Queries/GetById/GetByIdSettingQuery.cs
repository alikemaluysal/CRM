using Application.Features.Settings.Constants;
using Application.Features.Settings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Settings.Constants.SettingsOperationClaims;

namespace Application.Features.Settings.Queries.GetById;

public class GetByIdSettingQuery : IRequest<GetByIdSettingResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdSettingQueryHandler : IRequestHandler<GetByIdSettingQuery, GetByIdSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISettingRepository _settingRepository;
        private readonly SettingBusinessRules _settingBusinessRules;

        public GetByIdSettingQueryHandler(IMapper mapper, ISettingRepository settingRepository, SettingBusinessRules settingBusinessRules)
        {
            _mapper = mapper;
            _settingRepository = settingRepository;
            _settingBusinessRules = settingBusinessRules;
        }

        public async Task<GetByIdSettingResponse> Handle(GetByIdSettingQuery request, CancellationToken cancellationToken)
        {
            Setting? setting = await _settingRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _settingBusinessRules.SettingShouldExistWhenSelected(setting);

            GetByIdSettingResponse response = _mapper.Map<GetByIdSettingResponse>(setting);
            return response;
        }
    }
}