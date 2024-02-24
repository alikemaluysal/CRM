using FluentValidation;

namespace Application.Features.Requests.Commands.Delete;

public class DeleteRequestCommandValidator : AbstractValidator<DeleteRequestCommand>
{
    public DeleteRequestCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}