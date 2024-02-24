using FluentValidation;

namespace Application.Features.UserAddresses.Commands.Update;

public class UpdateUserAddressCommandValidator : AbstractValidator<UpdateUserAddressCommand>
{
    public UpdateUserAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.AddressType).NotEmpty();
    }
}