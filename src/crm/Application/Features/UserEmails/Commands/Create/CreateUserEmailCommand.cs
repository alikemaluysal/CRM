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

namespace Application.Features.UserEmails.Commands.Create;

public class CreateUserEmailCommand : IRequest<CreatedUserEmailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid? UserId { get; set; }
    public string? EmailAddress { get; set; }
    public EmailTypeEnum EmailType { get; set; }

    public string[] Roles => [Admin, Write, UserEmailsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserEmails"];

    public class CreateUserEmailCommandHandler : IRequestHandler<CreateUserEmailCommand, CreatedUserEmailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmailRepository _userEmailRepository;
        private readonly UserEmailBusinessRules _userEmailBusinessRules;

        public CreateUserEmailCommandHandler(IMapper mapper, IUserEmailRepository userEmailRepository,
                                         UserEmailBusinessRules userEmailBusinessRules)
        {
            _mapper = mapper;
            _userEmailRepository = userEmailRepository;
            _userEmailBusinessRules = userEmailBusinessRules;
        }

        public async Task<CreatedUserEmailResponse> Handle(CreateUserEmailCommand request, CancellationToken cancellationToken)
        {
            UserEmail userEmail = _mapper.Map<UserEmail>(request);

            await _userEmailRepository.AddAsync(userEmail);

            CreatedUserEmailResponse response = _mapper.Map<CreatedUserEmailResponse>(userEmail);
            return response;
        }
    }
}