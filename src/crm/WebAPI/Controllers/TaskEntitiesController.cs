using Application.Features.TaskEntities.Commands.Create;
using Application.Features.TaskEntities.Commands.Delete;
using Application.Features.TaskEntities.Commands.Update;
using Application.Features.TaskEntities.Queries.GetById;
using Application.Features.TaskEntities.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskEntitiesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTaskEntityCommand createTaskEntityCommand)
    {
        CreatedTaskEntityResponse response = await Mediator.Send(createTaskEntityCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTaskEntityCommand updateTaskEntityCommand)
    {
        UpdatedTaskEntityResponse response = await Mediator.Send(updateTaskEntityCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedTaskEntityResponse response = await Mediator.Send(new DeleteTaskEntityCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdTaskEntityResponse response = await Mediator.Send(new GetByIdTaskEntityQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTaskEntityQuery getListTaskEntityQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTaskEntityListItemDto> response = await Mediator.Send(getListTaskEntityQuery);
        return Ok(response);
    }
}