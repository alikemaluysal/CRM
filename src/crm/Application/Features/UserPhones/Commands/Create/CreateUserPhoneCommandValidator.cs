using FluentValidation;

namespace Application.Features.UserPhones.Commands.Create;

public class CreateUserPhoneCommandValidator : AbstractValidator<CreateUserPhoneCommand>
{
    public CreateUserPhoneCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.PhoneType).NotEmpty();
    }
}