using Application.Features.Titles.Commands.Create;
using Application.Features.Titles.Commands.Delete;
using Application.Features.Titles.Commands.Update;
using Application.Features.Titles.Queries.GetById;
using Application.Features.Titles.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Titles.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Title, CreateTitleCommand>().ReverseMap();
        CreateMap<Title, CreatedTitleResponse>().ReverseMap();
        CreateMap<Title, UpdateTitleCommand>().ReverseMap();
        CreateMap<Title, UpdatedTitleResponse>().ReverseMap();
        CreateMap<Title, DeleteTitleCommand>().ReverseMap();
        CreateMap<Title, DeletedTitleResponse>().ReverseMap();
        CreateMap<Title, GetByIdTitleResponse>().ReverseMap();
        CreateMap<Title, GetListTitleListItemDto>().ReverseMap();
        CreateMap<IPaginate<Title>, GetListResponse<GetListTitleListItemDto>>().ReverseMap();
    }
}