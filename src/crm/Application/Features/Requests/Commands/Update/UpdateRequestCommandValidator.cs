using FluentValidation;

namespace Application.Features.Requests.Commands.Update;

public class UpdateRequestCommandValidator : AbstractValidator<UpdateRequestCommand>
{
    public UpdateRequestCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerUserId).NotEmpty();
        RuleFor(c => c.EmployeeUserId).NotEmpty();
        RuleFor(c => c.RequestStatusId).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}