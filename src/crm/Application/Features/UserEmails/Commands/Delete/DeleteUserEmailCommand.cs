using Application.Features.UserEmails.Constants;
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
using static Application.Features.UserEmails.Constants.UserEmailsOperationClaims;

namespace Application.Features.UserEmails.Commands.Delete;

public class DeleteUserEmailCommand : IRequest<DeletedUserEmailResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, UserEmailsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserEmails"];

    public class DeleteUserEmailCommandHandler : IRequestHandler<DeleteUserEmailCommand, DeletedUserEmailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserEmailRepository _userEmailRepository;
        private readonly UserEmailBusinessRules _userEmailBusinessRules;

        public DeleteUserEmailCommandHandler(IMapper mapper, IUserEmailRepository userEmailRepository,
                                         UserEmailBusinessRules userEmailBusinessRules)
        {
            _mapper = mapper;
            _userEmailRepository = userEmailRepository;
            _userEmailBusinessRules = userEmailBusinessRules;
        }

        public async Task<DeletedUserEmailResponse> Handle(DeleteUserEmailCommand request, CancellationToken cancellationToken)
        {
            UserEmail? userEmail = await _userEmailRepository.GetAsync(predicate: ue => ue.Id == request.Id, cancellationToken: cancellationToken);
            await _userEmailBusinessRules.UserEmailShouldExistWhenSelected(userEmail);

            await _userEmailRepository.DeleteAsync(userEmail!);

            DeletedUserEmailResponse response = _mapper.Map<DeletedUserEmailResponse>(userEmail);
            return response;
        }
    }
}