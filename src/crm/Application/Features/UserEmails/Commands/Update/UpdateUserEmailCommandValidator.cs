using FluentValidation;

namespace Application.Features.UserEmails.Commands.Update;

public class UpdateUserEmailCommandValidator : AbstractValidator<UpdateUserEmailCommand>
{
    public UpdateUserEmailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.EmailAddress).NotEmpty();
        RuleFor(c => c.EmailType).NotEmpty();
    }
}