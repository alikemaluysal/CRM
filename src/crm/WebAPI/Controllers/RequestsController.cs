using Application.Features.Requests.Commands.Create;
using Application.Features.Requests.Commands.Delete;
using Application.Features.Requests.Commands.Update;
using Application.Features.Requests.Queries.GetById;
using Application.Features.Requests.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRequestCommand createRequestCommand)
    {
        CreatedRequestResponse response = await Mediator.Send(createRequestCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRequestCommand updateRequestCommand)
    {
        UpdatedRequestResponse response = await Mediator.Send(updateRequestCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedRequestResponse response = await Mediator.Send(new DeleteRequestCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdRequestResponse response = await Mediator.Send(new GetByIdRequestQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRequestQuery getListRequestQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRequestListItemDto> response = await Mediator.Send(getListRequestQuery);
        return Ok(response);
    }
}