using Application.Features.UserPhones.Commands.Create;
using Application.Features.UserPhones.Commands.Delete;
using Application.Features.UserPhones.Commands.Update;
using Application.Features.UserPhones.Queries.GetById;
using Application.Features.UserPhones.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserPhones.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserPhone, CreateUserPhoneCommand>().ReverseMap();
        CreateMap<UserPhone, CreatedUserPhoneResponse>().ReverseMap();
        CreateMap<UserPhone, UpdateUserPhoneCommand>().ReverseMap();
        CreateMap<UserPhone, UpdatedUserPhoneResponse>().ReverseMap();
        CreateMap<UserPhone, DeleteUserPhoneCommand>().ReverseMap();
        CreateMap<UserPhone, DeletedUserPhoneResponse>().ReverseMap();
        CreateMap<UserPhone, GetByIdUserPhoneResponse>().ReverseMap();
        CreateMap<UserPhone, GetListUserPhoneListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserPhone>, GetListResponse<GetListUserPhoneListItemDto>>().ReverseMap();
    }
}