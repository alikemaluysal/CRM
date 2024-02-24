using Application.Features.TaskStatuses.Commands.Create;
using Application.Features.TaskStatuses.Commands.Delete;
using Application.Features.TaskStatuses.Commands.Update;
using Application.Features.TaskStatuses.Queries.GetById;
using Application.Features.TaskStatuses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Application.Features.TaskStatuses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TaskStatus, CreateTaskStatusCommand>().ReverseMap();
        CreateMap<TaskStatus, CreatedTaskStatusResponse>().ReverseMap();
        CreateMap<TaskStatus, UpdateTaskStatusCommand>().ReverseMap();
        CreateMap<TaskStatus, UpdatedTaskStatusResponse>().ReverseMap();
        CreateMap<TaskStatus, DeleteTaskStatusCommand>().ReverseMap();
        CreateMap<TaskStatus, DeletedTaskStatusResponse>().ReverseMap();
        CreateMap<TaskStatus, GetByIdTaskStatusResponse>().ReverseMap();
        CreateMap<TaskStatus, GetListTaskStatusListItemDto>().ReverseMap();
        CreateMap<IPaginate<TaskStatus>, GetListResponse<GetListTaskStatusListItemDto>>().ReverseMap();
    }
}