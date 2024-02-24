using Application.Features.TaskEntities.Commands.Create;
using Application.Features.TaskEntities.Commands.Delete;
using Application.Features.TaskEntities.Commands.Update;
using Application.Features.TaskEntities.Queries.GetById;
using Application.Features.TaskEntities.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.TaskEntities.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TaskEntity, CreateTaskEntityCommand>().ReverseMap();
        CreateMap<TaskEntity, CreatedTaskEntityResponse>().ReverseMap();
        CreateMap<TaskEntity, UpdateTaskEntityCommand>().ReverseMap();
        CreateMap<TaskEntity, UpdatedTaskEntityResponse>().ReverseMap();
        CreateMap<TaskEntity, DeleteTaskEntityCommand>().ReverseMap();
        CreateMap<TaskEntity, DeletedTaskEntityResponse>().ReverseMap();
        CreateMap<TaskEntity, GetByIdTaskEntityResponse>().ReverseMap();
        CreateMap<TaskEntity, GetListTaskEntityListItemDto>().ReverseMap();
        CreateMap<IPaginate<TaskEntity>, GetListResponse<GetListTaskEntityListItemDto>>().ReverseMap();
    }
}