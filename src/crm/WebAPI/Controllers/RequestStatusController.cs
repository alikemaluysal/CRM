using Application.Features.RequestStatuses.Commands.Create;
using Application.Features.RequestStatuses.Commands.Delete;
using Application.Features.RequestStatuses.Commands.Update;
using Application.Features.RequestStatuses.Queries.GetById;
using Application.Features.RequestStatuses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestStatusController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRequestStatusCommand createRequestStatusCommand)
    {
        CreatedRequestStatusResponse response = await Mediator.Send(createRequestStatusCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRequestStatusCommand updateRequestStatusCommand)
    {
        UpdatedRequestStatusResponse response = await Mediator.Send(updateRequestStatusCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedRequestStatusResponse response = await Mediator.Send(new DeleteRequestStatusCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdRequestStatusResponse response = await Mediator.Send(new GetByIdRequestStatusQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRequestStatusQuery getListRequestStatusQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRequestStatusListItemDto> response = await Mediator.Send(getListRequestStatusQuery);
        return Ok(response);
    }
}