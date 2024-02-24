using Application.Features.Settings.Commands.Create;
using Application.Features.Settings.Commands.Delete;
using Application.Features.Settings.Commands.Update;
using Application.Features.Settings.Queries.GetById;
using Application.Features.Settings.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SettingsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSettingCommand createSettingCommand)
    {
        CreatedSettingResponse response = await Mediator.Send(createSettingCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSettingCommand updateSettingCommand)
    {
        UpdatedSettingResponse response = await Mediator.Send(updateSettingCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSettingResponse response = await Mediator.Send(new DeleteSettingCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSettingResponse response = await Mediator.Send(new GetByIdSettingQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSettingQuery getListSettingQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSettingListItemDto> response = await Mediator.Send(getListSettingQuery);
        return Ok(response);
    }
}