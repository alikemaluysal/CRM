using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.UserEmails.Queries.GetList;

public class GetListUserEmailListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid? UserId { get; set; }
    public string? EmailAddress { get; set; }
    public EmailTypeEnum EmailType { get; set; }
}