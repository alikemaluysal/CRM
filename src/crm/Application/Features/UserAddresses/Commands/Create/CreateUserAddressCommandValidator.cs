using FluentValidation;

namespace Application.Features.UserAddresses.Commands.Create;

public class CreateUserAddressCommandValidator : AbstractValidator<CreateUserAddressCommand>
{
    public CreateUserAddressCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.AddressType).NotEmpty();
    }
}