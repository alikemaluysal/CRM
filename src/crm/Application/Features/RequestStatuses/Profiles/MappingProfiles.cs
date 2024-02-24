using Application.Features.RequestStatuses.Commands.Create;
using Application.Features.RequestStatuses.Commands.Delete;
using Application.Features.RequestStatuses.Commands.Update;
using Application.Features.RequestStatuses.Queries.GetById;
using Application.Features.RequestStatuses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.RequestStatuses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RequestStatus, CreateRequestStatusCommand>().ReverseMap();
        CreateMap<RequestStatus, CreatedRequestStatusResponse>().ReverseMap();
        CreateMap<RequestStatus, UpdateRequestStatusCommand>().ReverseMap();
        CreateMap<RequestStatus, UpdatedRequestStatusResponse>().ReverseMap();
        CreateMap<RequestStatus, DeleteRequestStatusCommand>().ReverseMap();
        CreateMap<RequestStatus, DeletedRequestStatusResponse>().ReverseMap();
        CreateMap<RequestStatus, GetByIdRequestStatusResponse>().ReverseMap();
        CreateMap<RequestStatus, GetListRequestStatusListItemDto>().ReverseMap();
        CreateMap<IPaginate<RequestStatus>, GetListResponse<GetListRequestStatusListItemDto>>().ReverseMap();
    }
}