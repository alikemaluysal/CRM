using FluentValidation;

namespace Application.Features.Customers.Commands.Update;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.IdentityNumber).NotEmpty();
        RuleFor(c => c.GenderId).NotEmpty();
        RuleFor(c => c.TitleId).NotEmpty();
        RuleFor(c => c.CompanyName).NotEmpty();
        RuleFor(c => c.StatusTypeId).NotEmpty();
        RuleFor(c => c.CustomerType).NotEmpty();
        RuleFor(c => c.RegionId).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
    }
}