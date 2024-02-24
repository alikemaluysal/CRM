using FluentValidation;

namespace Application.Features.TaskEntities.Commands.Delete;

public class DeleteTaskEntityCommandValidator : AbstractValidator<DeleteTaskEntityCommand>
{
    public DeleteTaskEntityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}