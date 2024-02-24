using Application.Features.UserEmails.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserEmails;

public class UserEmailManager : IUserEmailService
{
    private readonly IUserEmailRepository _userEmailRepository;
    private readonly UserEmailBusinessRules _userEmailBusinessRules;

    public UserEmailManager(IUserEmailRepository userEmailRepository, UserEmailBusinessRules userEmailBusinessRules)
    {
        _userEmailRepository = userEmailRepository;
        _userEmailBusinessRules = userEmailBusinessRules;
    }

    public async Task<UserEmail?> GetAsync(
        Expression<Func<UserEmail, bool>> predicate,
        Func<IQueryable<UserEmail>, IIncludableQueryable<UserEmail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserEmail? userEmail = await _userEmailRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userEmail;
    }

    public async Task<IPaginate<UserEmail>?> GetListAsync(
        Expression<Func<UserEmail, bool>>? predicate = null,
        Func<IQueryable<UserEmail>, IOrderedQueryable<UserEmail>>? orderBy = null,
        Func<IQueryable<UserEmail>, IIncludableQueryable<UserEmail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserEmail> userEmailList = await _userEmailRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userEmailList;
    }

    public async Task<UserEmail> AddAsync(UserEmail userEmail)
    {
        UserEmail addedUserEmail = await _userEmailRepository.AddAsync(userEmail);

        return addedUserEmail;
    }

    public async Task<UserEmail> UpdateAsync(UserEmail userEmail)
    {
        UserEmail updatedUserEmail = await _userEmailRepository.UpdateAsync(userEmail);

        return updatedUserEmail;
    }

    public async Task<UserEmail> DeleteAsync(UserEmail userEmail, bool permanent = false)
    {
        UserEmail deletedUserEmail = await _userEmailRepository.DeleteAsync(userEmail);

        return deletedUserEmail;
    }
}
