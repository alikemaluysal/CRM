using Application.Features.UserPhones.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserPhones;

public class UserPhoneManager : IUserPhoneService
{
    private readonly IUserPhoneRepository _userPhoneRepository;
    private readonly UserPhoneBusinessRules _userPhoneBusinessRules;

    public UserPhoneManager(IUserPhoneRepository userPhoneRepository, UserPhoneBusinessRules userPhoneBusinessRules)
    {
        _userPhoneRepository = userPhoneRepository;
        _userPhoneBusinessRules = userPhoneBusinessRules;
    }

    public async Task<UserPhone?> GetAsync(
        Expression<Func<UserPhone, bool>> predicate,
        Func<IQueryable<UserPhone>, IIncludableQueryable<UserPhone, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserPhone? userPhone = await _userPhoneRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userPhone;
    }

    public async Task<IPaginate<UserPhone>?> GetListAsync(
        Expression<Func<UserPhone, bool>>? predicate = null,
        Func<IQueryable<UserPhone>, IOrderedQueryable<UserPhone>>? orderBy = null,
        Func<IQueryable<UserPhone>, IIncludableQueryable<UserPhone, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserPhone> userPhoneList = await _userPhoneRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userPhoneList;
    }

    public async Task<UserPhone> AddAsync(UserPhone userPhone)
    {
        UserPhone addedUserPhone = await _userPhoneRepository.AddAsync(userPhone);

        return addedUserPhone;
    }

    public async Task<UserPhone> UpdateAsync(UserPhone userPhone)
    {
        UserPhone updatedUserPhone = await _userPhoneRepository.UpdateAsync(userPhone);

        return updatedUserPhone;
    }

    public async Task<UserPhone> DeleteAsync(UserPhone userPhone, bool permanent = false)
    {
        UserPhone deletedUserPhone = await _userPhoneRepository.DeleteAsync(userPhone);

        return deletedUserPhone;
    }
}
