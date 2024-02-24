using FluentValidation;

namespace Application.Features.StatusTypes.Commands.Update;

public class UpdateStatusTypeCommandValidator : AbstractValidator<UpdateStatusTypeCommand>
{
    public UpdateStatusTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}