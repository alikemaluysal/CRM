using Application.Features.Settings.Constants;
using Application.Features.Settings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Settings.Constants.SettingsOperationClaims;

namespace Application.Features.Settings.Commands.Create;

public class CreateSettingCommand : IRequest<CreatedSettingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid UserId { get; set; }
    public string SettingKey { get; set; }
    public string SettingValue { get; set; }

    public string[] Roles => [Admin, Write, SettingsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSettings"];

    public class CreateSettingCommandHandler : IRequestHandler<CreateSettingCommand, CreatedSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISettingRepository _settingRepository;
        private readonly SettingBusinessRules _settingBusinessRules;

        public CreateSettingCommandHandler(IMapper mapper, ISettingRepository settingRepository,
                                         SettingBusinessRules settingBusinessRules)
        {
            _mapper = mapper;
            _settingRepository = settingRepository;
            _settingBusinessRules = settingBusinessRules;
        }

        public async Task<CreatedSettingResponse> Handle(CreateSettingCommand request, CancellationToken cancellationToken)
        {
            Setting setting = _mapper.Map<Setting>(request);

            await _settingRepository.AddAsync(setting);

            CreatedSettingResponse response = _mapper.Map<CreatedSettingResponse>(setting);
            return response;
        }
    }
}