using Application.Features.Regions.Commands.Create;
using Application.Features.Regions.Commands.Delete;
using Application.Features.Regions.Commands.Update;
using Application.Features.Regions.Queries.GetById;
using Application.Features.Regions.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRegionCommand createRegionCommand)
    {
        CreatedRegionResponse response = await Mediator.Send(createRegionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRegionCommand updateRegionCommand)
    {
        UpdatedRegionResponse response = await Mediator.Send(updateRegionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedRegionResponse response = await Mediator.Send(new DeleteRegionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdRegionResponse response = await Mediator.Send(new GetByIdRegionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRegionQuery getListRegionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRegionListItemDto> response = await Mediator.Send(getListRegionQuery);
        return Ok(response);
    }
}