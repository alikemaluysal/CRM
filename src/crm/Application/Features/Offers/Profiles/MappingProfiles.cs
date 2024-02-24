using Application.Features.Offers.Commands.Create;
using Application.Features.Offers.Commands.Delete;
using Application.Features.Offers.Commands.Update;
using Application.Features.Offers.Queries.GetById;
using Application.Features.Offers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Offers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Offer, CreateOfferCommand>().ReverseMap();
        CreateMap<Offer, CreatedOfferResponse>().ReverseMap();
        CreateMap<Offer, UpdateOfferCommand>().ReverseMap();
        CreateMap<Offer, UpdatedOfferResponse>().ReverseMap();
        CreateMap<Offer, DeleteOfferCommand>().ReverseMap();
        CreateMap<Offer, DeletedOfferResponse>().ReverseMap();
        CreateMap<Offer, GetByIdOfferResponse>().ReverseMap();
        CreateMap<Offer, GetListOfferListItemDto>().ReverseMap();
        CreateMap<IPaginate<Offer>, GetListResponse<GetListOfferListItemDto>>().ReverseMap();
    }
}