using FluentValidation;

namespace Application.Features.TaskEntities.Commands.Create;

public class CreateTaskEntityCommandValidator : AbstractValidator<CreateTaskEntityCommand>
{
    public CreateTaskEntityCommandValidator()
    {
        RuleFor(c => c.RequestId).NotEmpty();
        RuleFor(c => c.EmployeeUserId).NotEmpty();
        RuleFor(c => c.TaskStartDate).NotEmpty();
        RuleFor(c => c.TaskEndDate).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.TaskStatusId).NotEmpty();
    }
}