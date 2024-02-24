using FluentValidation;

namespace Application.Features.StatusTypes.Commands.Create;

public class CreateStatusTypeCommandValidator : AbstractValidator<CreateStatusTypeCommand>
{
    public CreateStatusTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}