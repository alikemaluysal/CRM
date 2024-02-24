using FluentValidation;

namespace Application.Features.Settings.Commands.Update;

public class UpdateSettingCommandValidator : AbstractValidator<UpdateSettingCommand>
{
    public UpdateSettingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.SettingKey).NotEmpty();
        RuleFor(c => c.SettingValue).NotEmpty();
    }
}