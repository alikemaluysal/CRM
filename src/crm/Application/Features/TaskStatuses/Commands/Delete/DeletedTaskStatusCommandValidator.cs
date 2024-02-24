using FluentValidation;

namespace Application.Features.TaskStatuses.Commands.Delete;

public class DeleteTaskStatusCommandValidator : AbstractValidator<DeleteTaskStatusCommand>
{
    public DeleteTaskStatusCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}