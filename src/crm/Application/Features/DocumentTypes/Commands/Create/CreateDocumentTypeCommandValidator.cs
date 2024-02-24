using FluentValidation;

namespace Application.Features.DocumentTypes.Commands.Create;

public class CreateDocumentTypeCommandValidator : AbstractValidator<CreateDocumentTypeCommand>
{
    public CreateDocumentTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}