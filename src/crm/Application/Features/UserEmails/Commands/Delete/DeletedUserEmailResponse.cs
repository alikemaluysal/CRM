using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserEmails.Commands.Delete;

public class DeletedUserEmailResponse : IResponse
{
    public Guid Id { get; set; }
}