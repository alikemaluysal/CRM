using FluentValidation;

namespace Application.Features.TaskEntities.Commands.Update;

public class UpdateTaskEntityCommandValidator : AbstractValidator<UpdateTaskEntityCommand>
{
    public UpdateTaskEntityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.RequestId).NotEmpty();
        RuleFor(c => c.EmployeeUserId).NotEmpty();
        RuleFor(c => c.TaskStartDate).NotEmpty();
        RuleFor(c => c.TaskEndDate).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.TaskStatusId).NotEmpty();
    }
}