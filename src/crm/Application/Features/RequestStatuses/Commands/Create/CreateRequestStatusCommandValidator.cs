using FluentValidation;

namespace Application.Features.RequestStatuses.Commands.Create;

public class CreateRequestStatusCommandValidator : AbstractValidator<CreateRequestStatusCommand>
{
    public CreateRequestStatusCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}