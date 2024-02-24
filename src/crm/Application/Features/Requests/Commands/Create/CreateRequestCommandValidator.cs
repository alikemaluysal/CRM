using FluentValidation;

namespace Application.Features.Requests.Commands.Create;

public class CreateRequestCommandValidator : AbstractValidator<CreateRequestCommand>
{
    public CreateRequestCommandValidator()
    {
        RuleFor(c => c.CustomerUserId).NotEmpty();
        RuleFor(c => c.EmployeeUserId).NotEmpty();
        RuleFor(c => c.RequestStatusId).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}