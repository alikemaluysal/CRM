using FluentValidation;

namespace Application.Features.Documents.Commands.Create;

public class CreateDocumentCommandValidator : AbstractValidator<CreateDocumentCommand>
{
    public CreateDocumentCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.RequestId).NotEmpty();
        RuleFor(c => c.DocumentFileName).NotEmpty();
        RuleFor(c => c.DocumentTypeId).NotEmpty();
    }
}