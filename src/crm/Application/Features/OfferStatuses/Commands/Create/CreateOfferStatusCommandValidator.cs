using FluentValidation;

namespace Application.Features.OfferStatuses.Commands.Create;

public class CreateOfferStatusCommandValidator : AbstractValidator<CreateOfferStatusCommand>
{
    public CreateOfferStatusCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}