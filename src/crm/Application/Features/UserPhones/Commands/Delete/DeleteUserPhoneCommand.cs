using Application.Features.UserPhones.Constants;
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
using static Application.Features.UserPhones.Constants.UserPhonesOperationClaims;

namespace Application.Features.UserPhones.Commands.Delete;

public class DeleteUserPhoneCommand : IRequest<DeletedUserPhoneResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, UserPhonesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserPhones"];

    public class DeleteUserPhoneCommandHandler : IRequestHandler<DeleteUserPhoneCommand, DeletedUserPhoneResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserPhoneRepository _userPhoneRepository;
        private readonly UserPhoneBusinessRules _userPhoneBusinessRules;

        public DeleteUserPhoneCommandHandler(IMapper mapper, IUserPhoneRepository userPhoneRepository,
                                         UserPhoneBusinessRules userPhoneBusinessRules)
        {
            _mapper = mapper;
            _userPhoneRepository = userPhoneRepository;
            _userPhoneBusinessRules = userPhoneBusinessRules;
        }

        public async Task<DeletedUserPhoneResponse> Handle(DeleteUserPhoneCommand request, CancellationToken cancellationToken)
        {
            UserPhone? userPhone = await _userPhoneRepository.GetAsync(predicate: up => up.Id == request.Id, cancellationToken: cancellationToken);
            await _userPhoneBusinessRules.UserPhoneShouldExistWhenSelected(userPhone);

            await _userPhoneRepository.DeleteAsync(userPhone!);

            DeletedUserPhoneResponse response = _mapper.Map<DeletedUserPhoneResponse>(userPhone);
            return response;
        }
    }
}