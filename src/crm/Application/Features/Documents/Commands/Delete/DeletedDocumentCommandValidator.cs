using FluentValidation;

namespace Application.Features.Documents.Commands.Delete;

public class DeleteDocumentCommandValidator : AbstractValidator<DeleteDocumentCommand>
{
    public DeleteDocumentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}