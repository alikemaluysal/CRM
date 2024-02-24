using Application.Features.UserPhones.Commands.Create;
using Application.Features.UserPhones.Commands.Delete;
using Application.Features.UserPhones.Commands.Update;
using Application.Features.UserPhones.Queries.GetById;
using Application.Features.UserPhones.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserPhonesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserPhoneCommand createUserPhoneCommand)
    {
        CreatedUserPhoneResponse response = await Mediator.Send(createUserPhoneCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserPhoneCommand updateUserPhoneCommand)
    {
        UpdatedUserPhoneResponse response = await Mediator.Send(updateUserPhoneCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedUserPhoneResponse response = await Mediator.Send(new DeleteUserPhoneCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserPhoneResponse response = await Mediator.Send(new GetByIdUserPhoneQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserPhoneQuery getListUserPhoneQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserPhoneListItemDto> response = await Mediator.Send(getListUserPhoneQuery);
        return Ok(response);
    }
}