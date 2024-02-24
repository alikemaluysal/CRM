using FluentValidation;

namespace Application.Features.Customers.Commands.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
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