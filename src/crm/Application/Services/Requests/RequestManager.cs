using Application.Features.Requests.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Requests;

public class RequestManager : IRequestService
{
    private readonly IRequestRepository _requestRepository;
    private readonly RequestBusinessRules _requestBusinessRules;

    public RequestManager(IRequestRepository requestRepository, RequestBusinessRules requestBusinessRules)
    {
        _requestRepository = requestRepository;
        _requestBusinessRules = requestBusinessRules;
    }

    public async Task<Request?> GetAsync(
        Expression<Func<Request, bool>> predicate,
        Func<IQueryable<Request>, IIncludableQueryable<Request, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Request? request = await _requestRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return request;
    }

    public async Task<IPaginate<Request>?> GetListAsync(
        Expression<Func<Request, bool>>? predicate = null,
        Func<IQueryable<Request>, IOrderedQueryable<Request>>? orderBy = null,
        Func<IQueryable<Request>, IIncludableQueryable<Request, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Request> requestList = await _requestRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return requestList;
    }

    public async Task<Request> AddAsync(Request request)
    {
        Request addedRequest = await _requestRepository.AddAsync(request);

        return addedRequest;
    }

    public async Task<Request> UpdateAsync(Request request)
    {
        Request updatedRequest = await _requestRepository.UpdateAsync(request);

        return updatedRequest;
    }

    public async Task<Request> DeleteAsync(Request request, bool permanent = false)
    {
        Request deletedRequest = await _requestRepository.DeleteAsync(request);

        return deletedRequest;
    }
}
