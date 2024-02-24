using FluentValidation;

namespace Application.Features.OfferStatuses.Commands.Delete;

public class DeleteOfferStatusCommandValidator : AbstractValidator<DeleteOfferStatusCommand>
{
    public DeleteOfferStatusCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}