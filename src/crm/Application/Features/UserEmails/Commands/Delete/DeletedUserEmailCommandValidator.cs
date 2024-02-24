using FluentValidation;

namespace Application.Features.UserEmails.Commands.Delete;

public class DeleteUserEmailCommandValidator : AbstractValidator<DeleteUserEmailCommand>
{
    public DeleteUserEmailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}