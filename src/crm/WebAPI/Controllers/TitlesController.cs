using Application.Features.Titles.Commands.Create;
using Application.Features.Titles.Commands.Delete;
using Application.Features.Titles.Commands.Update;
using Application.Features.Titles.Queries.GetById;
using Application.Features.Titles.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TitlesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTitleCommand createTitleCommand)
    {
        CreatedTitleResponse response = await Mediator.Send(createTitleCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTitleCommand updateTitleCommand)
    {
        UpdatedTitleResponse response = await Mediator.Send(updateTitleCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedTitleResponse response = await Mediator.Send(new DeleteTitleCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdTitleResponse response = await Mediator.Send(new GetByIdTitleQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTitleQuery getListTitleQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTitleListItemDto> response = await Mediator.Send(getListTitleQuery);
        return Ok(response);
    }
}