using NArchitecture.Core.Application.Responses;

namespace Application.Features.Settings.Commands.Delete;

public class DeletedSettingResponse : IResponse
{
    public Guid Id { get; set; }
}