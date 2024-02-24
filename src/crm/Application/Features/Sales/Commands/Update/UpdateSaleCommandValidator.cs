using FluentValidation;

namespace Application.Features.Sales.Commands.Update;

public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.RequestId).NotEmpty();
        RuleFor(c => c.EmployeeUserId).NotEmpty();
        RuleFor(c => c.SaleDate).NotEmpty();
        RuleFor(c => c.SaleAmount).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}