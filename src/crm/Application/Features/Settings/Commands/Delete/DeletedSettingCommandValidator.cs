using FluentValidation;

namespace Application.Features.Settings.Commands.Delete;

public class DeleteSettingCommandValidator : AbstractValidator<DeleteSettingCommand>
{
    public DeleteSettingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}