using Application.Features.Departments.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Departments.Constants.DepartmentsOperationClaims;

namespace Application.Features.Departments.Queries.GetList;

public class GetListDepartmentQuery : IRequest<GetListResponse<GetListDepartmentListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListDepartments({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetDepartments";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListDepartmentQueryHandler : IRequestHandler<GetListDepartmentQuery, GetListResponse<GetListDepartmentListItemDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public GetListDepartmentQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDepartmentListItemDto>> Handle(GetListDepartmentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Department> departments = await _departmentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDepartmentListItemDto> response = _mapper.Map<GetListResponse<GetListDepartmentListItemDto>>(departments);
            return response;
        }
    }
}