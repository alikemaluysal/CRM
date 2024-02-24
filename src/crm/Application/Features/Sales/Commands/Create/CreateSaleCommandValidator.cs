using FluentValidation;

namespace Application.Features.Sales.Commands.Create;

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(c => c.RequestId).NotEmpty();
        RuleFor(c => c.EmployeeUserId).NotEmpty();
        RuleFor(c => c.SaleDate).NotEmpty();
        RuleFor(c => c.SaleAmount).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}