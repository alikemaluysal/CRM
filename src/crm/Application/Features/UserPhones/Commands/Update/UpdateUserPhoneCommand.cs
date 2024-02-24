using Application.Features.UserPhones.Constants;
using Application.Features.UserPhones.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using static Application.Features.UserPhones.Constants.UserPhonesOperationClaims;

namespace Application.Features.UserPhones.Commands.Update;

public class UpdateUserPhoneCommand : IRequest<UpdatedUserPhoneResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? PhoneNumber { get; set; }
    public PhoneTypeEnum PhoneType { get; set; }

    public string[] Roles => [Admin, Write, UserPhonesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserPhones"];

    public class UpdateUserPhoneCommandHandler : IRequestHandler<UpdateUserPhoneCommand, UpdatedUserPhoneResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserPhoneRepository _userPhoneRepository;
        private readonly UserPhoneBusinessRules _userPhoneBusinessRules;

        public UpdateUserPhoneCommandHandler(IMapper mapper, IUserPhoneRepository userPhoneRepository,
                                         UserPhoneBusinessRules userPhoneBusinessRules)
        {
            _mapper = mapper;
            _userPhoneRepository = userPhoneRepository;
            _userPhoneBusinessRules = userPhoneBusinessRules;
        }

        public async Task<UpdatedUserPhoneResponse> Handle(UpdateUserPhoneCommand request, CancellationToken cancellationToken)
        {
            UserPhone? userPhone = await _userPhoneRepository.GetAsync(predicate: up => up.Id == request.Id, cancellationToken: cancellationToken);
            await _userPhoneBusinessRules.UserPhoneShouldExistWhenSelected(userPhone);
            userPhone = _mapper.Map(request, userPhone);

            await _userPhoneRepository.UpdateAsync(userPhone!);

            UpdatedUserPhoneResponse response = _mapper.Map<UpdatedUserPhoneResponse>(userPhone);
            return response;
        }
    }
}