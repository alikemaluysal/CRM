using Application.Features.Regions.Commands.Create;
using Application.Features.Regions.Commands.Delete;
using Application.Features.Regions.Commands.Update;
using Application.Features.Regions.Queries.GetById;
using Application.Features.Regions.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Regions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Region, CreateRegionCommand>().ReverseMap();
        CreateMap<Region, CreatedRegionResponse>().ReverseMap();
        CreateMap<Region, UpdateRegionCommand>().ReverseMap();
        CreateMap<Region, UpdatedRegionResponse>().ReverseMap();
        CreateMap<Region, DeleteRegionCommand>().ReverseMap();
        CreateMap<Region, DeletedRegionResponse>().ReverseMap();
        CreateMap<Region, GetByIdRegionResponse>().ReverseMap();
        CreateMap<Region, GetListRegionListItemDto>().ReverseMap();
        CreateMap<IPaginate<Region>, GetListResponse<GetListRegionListItemDto>>().ReverseMap();
    }
}