using NArchitecture.Core.Application.Responses;

namespace Application.Features.Settings.Commands.Update;

public class UpdatedSettingResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string SettingKey { get; set; }
    public string SettingValue { get; set; }
}