using Application.Features.StatusTypes.Commands.Create;
using Application.Features.StatusTypes.Commands.Delete;
using Application.Features.StatusTypes.Commands.Update;
using Application.Features.StatusTypes.Queries.GetById;
using Application.Features.StatusTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.StatusTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StatusType, CreateStatusTypeCommand>().ReverseMap();
        CreateMap<StatusType, CreatedStatusTypeResponse>().ReverseMap();
        CreateMap<StatusType, UpdateStatusTypeCommand>().ReverseMap();
        CreateMap<StatusType, UpdatedStatusTypeResponse>().ReverseMap();
        CreateMap<StatusType, DeleteStatusTypeCommand>().ReverseMap();
        CreateMap<StatusType, DeletedStatusTypeResponse>().ReverseMap();
        CreateMap<StatusType, GetByIdStatusTypeResponse>().ReverseMap();
        CreateMap<StatusType, GetListStatusTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<StatusType>, GetListResponse<GetListStatusTypeListItemDto>>().ReverseMap();
    }
}