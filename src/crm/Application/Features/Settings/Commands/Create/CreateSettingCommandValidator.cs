using FluentValidation;

namespace Application.Features.Settings.Commands.Create;

public class CreateSettingCommandValidator : AbstractValidator<CreateSettingCommand>
{
    public CreateSettingCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.SettingKey).NotEmpty();
        RuleFor(c => c.SettingValue).NotEmpty();
    }
}