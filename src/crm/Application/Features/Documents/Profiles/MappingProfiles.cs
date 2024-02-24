using Application.Features.Documents.Commands.Create;
using Application.Features.Documents.Commands.Delete;
using Application.Features.Documents.Commands.Update;
using Application.Features.Documents.Queries.GetById;
using Application.Features.Documents.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Documents.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Document, CreateDocumentCommand>().ReverseMap();
        CreateMap<Document, CreatedDocumentResponse>().ReverseMap();
        CreateMap<Document, UpdateDocumentCommand>().ReverseMap();
        CreateMap<Document, UpdatedDocumentResponse>().ReverseMap();
        CreateMap<Document, DeleteDocumentCommand>().ReverseMap();
        CreateMap<Document, DeletedDocumentResponse>().ReverseMap();
        CreateMap<Document, GetByIdDocumentResponse>().ReverseMap();
        CreateMap<Document, GetListDocumentListItemDto>().ReverseMap();
        CreateMap<IPaginate<Document>, GetListResponse<GetListDocumentListItemDto>>().ReverseMap();
    }
}