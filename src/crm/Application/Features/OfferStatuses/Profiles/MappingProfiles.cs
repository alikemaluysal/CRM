using Application.Features.OfferStatuses.Commands.Create;
using Application.Features.OfferStatuses.Commands.Delete;
using Application.Features.OfferStatuses.Commands.Update;
using Application.Features.OfferStatuses.Queries.GetById;
using Application.Features.OfferStatuses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.OfferStatuses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OfferStatus, CreateOfferStatusCommand>().ReverseMap();
        CreateMap<OfferStatus, CreatedOfferStatusResponse>().ReverseMap();
        CreateMap<OfferStatus, UpdateOfferStatusCommand>().ReverseMap();
        CreateMap<OfferStatus, UpdatedOfferStatusResponse>().ReverseMap();
        CreateMap<OfferStatus, DeleteOfferStatusCommand>().ReverseMap();
        CreateMap<OfferStatus, DeletedOfferStatusResponse>().ReverseMap();
        CreateMap<OfferStatus, GetByIdOfferStatusResponse>().ReverseMap();
        CreateMap<OfferStatus, GetListOfferStatusListItemDto>().ReverseMap();
        CreateMap<IPaginate<OfferStatus>, GetListResponse<GetListOfferStatusListItemDto>>().ReverseMap();
    }
}