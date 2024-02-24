using FluentValidation;

namespace Application.Features.Employees.Commands.Create;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.IdentityNumber).NotEmpty();
        RuleFor(c => c.GenderId).NotEmpty();
        RuleFor(c => c.TitleId).NotEmpty();
        RuleFor(c => c.DepartmentId).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.StatusTypeId).NotEmpty();
        RuleFor(c => c.RegionId).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.ParentEmployeeId).NotEmpty();
    }
}