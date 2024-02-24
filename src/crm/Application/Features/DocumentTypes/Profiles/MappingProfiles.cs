using Application.Features.DocumentTypes.Commands.Create;
using Application.Features.DocumentTypes.Commands.Delete;
using Application.Features.DocumentTypes.Commands.Update;
using Application.Features.DocumentTypes.Queries.GetById;
using Application.Features.DocumentTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.DocumentTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<DocumentType, CreateDocumentTypeCommand>().ReverseMap();
        CreateMap<DocumentType, CreatedDocumentTypeResponse>().ReverseMap();
        CreateMap<DocumentType, UpdateDocumentTypeCommand>().ReverseMap();
        CreateMap<DocumentType, UpdatedDocumentTypeResponse>().ReverseMap();
        CreateMap<DocumentType, DeleteDocumentTypeCommand>().ReverseMap();
        CreateMap<DocumentType, DeletedDocumentTypeResponse>().ReverseMap();
        CreateMap<DocumentType, GetByIdDocumentTypeResponse>().ReverseMap();
        CreateMap<DocumentType, GetListDocumentTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<DocumentType>, GetListResponse<GetListDocumentTypeListItemDto>>().ReverseMap();
    }
}