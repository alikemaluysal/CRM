using Application.Features.TaskStatuses.Commands.Create;
using Application.Features.TaskStatuses.Commands.Delete;
using Application.Features.TaskStatuses.Commands.Update;
using Application.Features.TaskStatuses.Queries.GetById;
using Application.Features.TaskStatuses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskStatusController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTaskStatusCommand createTaskStatusCommand)
    {
        CreatedTaskStatusResponse response = await Mediator.Send(createTaskStatusCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTaskStatusCommand updateTaskStatusCommand)
    {
        UpdatedTaskStatusResponse response = await Mediator.Send(updateTaskStatusCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedTaskStatusResponse response = await Mediator.Send(new DeleteTaskStatusCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdTaskStatusResponse response = await Mediator.Send(new GetByIdTaskStatusQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTaskStatusQuery getListTaskStatusQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTaskStatusListItemDto> response = await Mediator.Send(getListTaskStatusQuery);
        return Ok(response);
    }
}