using FluentValidation;

namespace Application.Features.DocumentTypes.Commands.Delete;

public class DeleteDocumentTypeCommandValidator : AbstractValidator<DeleteDocumentTypeCommand>
{
    public DeleteDocumentTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}