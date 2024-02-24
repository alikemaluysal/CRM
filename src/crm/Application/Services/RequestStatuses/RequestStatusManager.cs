using Application.Features.RequestStatuses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RequestStatuses;

public class RequestStatusManager : IRequestStatusService
{
    private readonly IRequestStatusRepository _requestStatusRepository;
    private readonly RequestStatusBusinessRules _requestStatusBusinessRules;

    public RequestStatusManager(IRequestStatusRepository requestStatusRepository, RequestStatusBusinessRules requestStatusBusinessRules)
    {
        _requestStatusRepository = requestStatusRepository;
        _requestStatusBusinessRules = requestStatusBusinessRules;
    }

    public async Task<RequestStatus?> GetAsync(
        Expression<Func<RequestStatus, bool>> predicate,
        Func<IQueryable<RequestStatus>, IIncludableQueryable<RequestStatus, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RequestStatus? requestStatus = await _requestStatusRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return requestStatus;
    }

    public async Task<IPaginate<RequestStatus>?> GetListAsync(
        Expression<Func<RequestStatus, bool>>? predicate = null,
        Func<IQueryable<RequestStatus>, IOrderedQueryable<RequestStatus>>? orderBy = null,
        Func<IQueryable<RequestStatus>, IIncludableQueryable<RequestStatus, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RequestStatus> requestStatusList = await _requestStatusRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return requestStatusList;
    }

    public async Task<RequestStatus> AddAsync(RequestStatus requestStatus)
    {
        RequestStatus addedRequestStatus = await _requestStatusRepository.AddAsync(requestStatus);

        return addedRequestStatus;
    }

    public async Task<RequestStatus> UpdateAsync(RequestStatus requestStatus)
    {
        RequestStatus updatedRequestStatus = await _requestStatusRepository.UpdateAsync(requestStatus);

        return updatedRequestStatus;
    }

    public async Task<RequestStatus> DeleteAsync(RequestStatus requestStatus, bool permanent = false)
    {
        RequestStatus deletedRequestStatus = await _requestStatusRepository.DeleteAsync(requestStatus);

        return deletedRequestStatus;
    }
}
