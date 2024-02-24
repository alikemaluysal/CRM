using FluentValidation;

namespace Application.Features.StatusTypes.Commands.Delete;

public class DeleteStatusTypeCommandValidator : AbstractValidator<DeleteStatusTypeCommand>
{
    public DeleteStatusTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}