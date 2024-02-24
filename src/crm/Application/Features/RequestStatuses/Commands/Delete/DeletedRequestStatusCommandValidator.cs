using FluentValidation;

namespace Application.Features.RequestStatuses.Commands.Delete;

public class DeleteRequestStatusCommandValidator : AbstractValidator<DeleteRequestStatusCommand>
{
    public DeleteRequestStatusCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}