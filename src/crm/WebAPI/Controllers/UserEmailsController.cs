using Application.Features.UserEmails.Commands.Create;
using Application.Features.UserEmails.Commands.Delete;
using Application.Features.UserEmails.Commands.Update;
using Application.Features.UserEmails.Queries.GetById;
using Application.Features.UserEmails.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserEmailsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserEmailCommand createUserEmailCommand)
    {
        CreatedUserEmailResponse response = await Mediator.Send(createUserEmailCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserEmailCommand updateUserEmailCommand)
    {
        UpdatedUserEmailResponse response = await Mediator.Send(updateUserEmailCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedUserEmailResponse response = await Mediator.Send(new DeleteUserEmailCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserEmailResponse response = await Mediator.Send(new GetByIdUserEmailQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserEmailQuery getListUserEmailQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserEmailListItemDto> response = await Mediator.Send(getListUserEmailQuery);
        return Ok(response);
    }
}