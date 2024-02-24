using FluentValidation;

namespace Application.Features.Offers.Commands.Delete;

public class DeleteOfferCommandValidator : AbstractValidator<DeleteOfferCommand>
{
    public DeleteOfferCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}