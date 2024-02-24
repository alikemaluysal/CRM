using Application.Features.UserEmails.Constants;
using Application.Features.UserEmails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using static Application.Features.UserEmails.Constants.UserEmailsOperationClaims;

namespace Application.Features.UserEmails.Commands.Update;

public class UpdateUserEmailCommand : IRequest<UpdatedUserEmailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid? UserId { get; set; }
    public string? EmailAddress { get; set; }
    public EmailTypeEnum EmailType { get; set; }

    public string[] Roles => [Admin, Write, UserEmailsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserEmails"];

    public class UpdateUserEmailCommandHandler : IRequestHandler<UpdateUserEmailCommand, UpdatedUserEmailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmailRepository _userEmailRepository;
        private readonly UserEmailBusinessRules _userEmailBusinessRules;

        public UpdateUserEmailCommandHandler(IMapper mapper, IUserEmailRepository userEmailRepository,
                                         UserEmailBusinessRules userEmailBusinessRules)
        {
            _mapper = mapper;
            _userEmailRepository = userEmailRepository;
            _userEmailBusinessRules = userEmailBusinessRules;
        }

        public async Task<UpdatedUserEmailResponse> Handle(UpdateUserEmailCommand request, CancellationToken cancellationToken)
        {
            UserEmail? userEmail = await _userEmailRepository.GetAsync(predicate: ue => ue.Id == request.Id, cancellationToken: cancellationToken);
            await _userEmailBusinessRules.UserEmailShouldExistWhenSelected(userEmail);
            userEmail = _mapper.Map(request, userEmail);

            await _userEmailRepository.UpdateAsync(userEmail!);

            UpdatedUserEmailResponse response = _mapper.Map<UpdatedUserEmailResponse>(userEmail);
            return response;
        }
    }
}