using Application.Features.Settings.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Settings;

public class SettingManager : ISettingService
{
    private readonly ISettingRepository _settingRepository;
    private readonly SettingBusinessRules _settingBusinessRules;

    public SettingManager(ISettingRepository settingRepository, SettingBusinessRules settingBusinessRules)
    {
        _settingRepository = settingRepository;
        _settingBusinessRules = settingBusinessRules;
    }

    public async Task<Setting?> GetAsync(
        Expression<Func<Setting, bool>> predicate,
        Func<IQueryable<Setting>, IIncludableQueryable<Setting, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Setting? setting = await _settingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return setting;
    }

    public async Task<IPaginate<Setting>?> GetListAsync(
        Expression<Func<Setting, bool>>? predicate = null,
        Func<IQueryable<Setting>, IOrderedQueryable<Setting>>? orderBy = null,
        Func<IQueryable<Setting>, IIncludableQueryable<Setting, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Setting> settingList = await _settingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return settingList;
    }

    public async Task<Setting> AddAsync(Setting setting)
    {
        Setting addedSetting = await _settingRepository.AddAsync(setting);

        return addedSetting;
    }

    public async Task<Setting> UpdateAsync(Setting setting)
    {
        Setting updatedSetting = await _settingRepository.UpdateAsync(setting);

        return updatedSetting;
    }

    public async Task<Setting> DeleteAsync(Setting setting, bool permanent = false)
    {
        Setting deletedSetting = await _settingRepository.DeleteAsync(setting);

        return deletedSetting;
    }
}
