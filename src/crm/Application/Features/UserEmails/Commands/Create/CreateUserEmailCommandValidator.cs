using FluentValidation;

namespace Application.Features.UserEmails.Commands.Create;

public class CreateUserEmailCommandValidator : AbstractValidator<CreateUserEmailCommand>
{
    public CreateUserEmailCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.EmailAddress).NotEmpty();
        RuleFor(c => c.EmailType).NotEmpty();
    }
}