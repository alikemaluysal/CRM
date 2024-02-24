using FluentValidation;

namespace Application.Features.TaskStatuses.Commands.Create;

public class CreateTaskStatusCommandValidator : AbstractValidator<CreateTaskStatusCommand>
{
    public CreateTaskStatusCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}