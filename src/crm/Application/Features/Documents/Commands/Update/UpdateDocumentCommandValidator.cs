using FluentValidation;

namespace Application.Features.Documents.Commands.Update;

public class UpdateDocumentCommandValidator : AbstractValidator<UpdateDocumentCommand>
{
    public UpdateDocumentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.RequestId).NotEmpty();
        RuleFor(c => c.DocumentFileName).NotEmpty();
        RuleFor(c => c.DocumentTypeId).NotEmpty();
    }
}