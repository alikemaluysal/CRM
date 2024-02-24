using FluentValidation;

namespace Application.Features.UserPhones.Commands.Delete;

public class DeleteUserPhoneCommandValidator : AbstractValidator<DeleteUserPhoneCommand>
{
    public DeleteUserPhoneCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}