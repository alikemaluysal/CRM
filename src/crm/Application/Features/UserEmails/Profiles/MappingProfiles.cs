using Application.Features.UserEmails.Commands.Create;
using Application.Features.UserEmails.Commands.Delete;
using Application.Features.UserEmails.Commands.Update;
using Application.Features.UserEmails.Queries.GetById;
using Application.Features.UserEmails.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserEmails.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserEmail, CreateUserEmailCommand>().ReverseMap();
        CreateMap<UserEmail, CreatedUserEmailResponse>().ReverseMap();
        CreateMap<UserEmail, UpdateUserEmailCommand>().ReverseMap();
        CreateMap<UserEmail, UpdatedUserEmailResponse>().ReverseMap();
        CreateMap<UserEmail, DeleteUserEmailCommand>().ReverseMap();
        CreateMap<UserEmail, DeletedUserEmailResponse>().ReverseMap();
        CreateMap<UserEmail, GetByIdUserEmailResponse>().ReverseMap();
        CreateMap<UserEmail, GetListUserEmailListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserEmail>, GetListResponse<GetListUserEmailListItemDto>>().ReverseMap();
    }
}