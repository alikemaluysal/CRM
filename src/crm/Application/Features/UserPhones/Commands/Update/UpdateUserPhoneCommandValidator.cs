using FluentValidation;

namespace Application.Features.UserPhones.Commands.Update;

public class UpdateUserPhoneCommandValidator : AbstractValidator<UpdateUserPhoneCommand>
{
    public UpdateUserPhoneCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.PhoneType).NotEmpty();
    }
}