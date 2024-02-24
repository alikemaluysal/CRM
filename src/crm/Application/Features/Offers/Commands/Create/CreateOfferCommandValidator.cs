using FluentValidation;

namespace Application.Features.Offers.Commands.Create;

public class CreateOfferCommandValidator : AbstractValidator<CreateOfferCommand>
{
    public CreateOfferCommandValidator()
    {
        RuleFor(c => c.RequestId).NotEmpty();
        RuleFor(c => c.EmployeeUserId).NotEmpty();
        RuleFor(c => c.OfferDate).NotEmpty();
        RuleFor(c => c.BidAmount).NotEmpty();
        RuleFor(c => c.OfferStatusId).NotEmpty();
    }
}