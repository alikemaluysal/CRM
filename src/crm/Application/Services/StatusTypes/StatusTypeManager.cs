using Application.Features.StatusTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StatusTypes;

public class StatusTypeManager : IStatusTypeService
{
    private readonly IStatusTypeRepository _statusTypeRepository;
    private readonly StatusTypeBusinessRules _statusTypeBusinessRules;

    public StatusTypeManager(IStatusTypeRepository statusTypeRepository, StatusTypeBusinessRules statusTypeBusinessRules)
    {
        _statusTypeRepository = statusTypeRepository;
        _statusTypeBusinessRules = statusTypeBusinessRules;
    }

    public async Task<StatusType?> GetAsync(
        Expression<Func<StatusType, bool>> predicate,
        Func<IQueryable<StatusType>, IIncludableQueryable<StatusType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StatusType? statusType = await _statusTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return statusType;
    }

    public async Task<IPaginate<StatusType>?> GetListAsync(
        Expression<Func<StatusType, bool>>? predicate = null,
        Func<IQueryable<StatusType>, IOrderedQueryable<StatusType>>? orderBy = null,
        Func<IQueryable<StatusType>, IIncludableQueryable<StatusType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StatusType> statusTypeList = await _statusTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return statusTypeList;
    }

    public async Task<StatusType> AddAsync(StatusType statusType)
    {
        StatusType addedStatusType = await _statusTypeRepository.AddAsync(statusType);

        return addedStatusType;
    }

    public async Task<StatusType> UpdateAsync(StatusType statusType)
    {
        StatusType updatedStatusType = await _statusTypeRepository.UpdateAsync(statusType);

        return updatedStatusType;
    }

    public async Task<StatusType> DeleteAsync(StatusType statusType, bool permanent = false)
    {
        StatusType deletedStatusType = await _statusTypeRepository.DeleteAsync(statusType);

        return deletedStatusType;
    }
}
