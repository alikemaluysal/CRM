using Application.Features.Requests.Commands.Create;
using Application.Features.Requests.Commands.Delete;
using Application.Features.Requests.Commands.Update;
using Application.Features.Requests.Queries.GetById;
using Application.Features.Requests.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Requests.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Request, CreateRequestCommand>().ReverseMap();
        CreateMap<Request, CreatedRequestResponse>().ReverseMap();
        CreateMap<Request, UpdateRequestCommand>().ReverseMap();
        CreateMap<Request, UpdatedRequestResponse>().ReverseMap();
        CreateMap<Request, DeleteRequestCommand>().ReverseMap();
        CreateMap<Request, DeletedRequestResponse>().ReverseMap();
        CreateMap<Request, GetByIdRequestResponse>().ReverseMap();
        CreateMap<Request, GetListRequestListItemDto>().ReverseMap();
        CreateMap<IPaginate<Request>, GetListResponse<GetListRequestListItemDto>>().ReverseMap();
    }
}