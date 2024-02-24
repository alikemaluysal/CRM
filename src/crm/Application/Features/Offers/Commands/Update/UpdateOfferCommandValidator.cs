using FluentValidation;

namespace Application.Features.Offers.Commands.Update;

public class UpdateOfferCommandValidator : AbstractValidator<UpdateOfferCommand>
{
    public UpdateOfferCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.RequestId).NotEmpty();
        RuleFor(c => c.EmployeeUserId).NotEmpty();
        RuleFor(c => c.OfferDate).NotEmpty();
        RuleFor(c => c.BidAmount).NotEmpty();
        RuleFor(c => c.OfferStatusId).NotEmpty();
    }
}