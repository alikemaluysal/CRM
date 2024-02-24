using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.UserEmails.Commands.Update;

public class UpdatedUserEmailResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid? UserId { get; set; }
    public string? EmailAddress { get; set; }
    public EmailTypeEnum EmailType { get; set; }
}