using Application.Features.Offers.Commands.Create;
using Application.Features.Offers.Commands.Delete;
using Application.Features.Offers.Commands.Update;
using Application.Features.Offers.Queries.GetById;
using Application.Features.Offers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OffersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOfferCommand createOfferCommand)
    {
        CreatedOfferResponse response = await Mediator.Send(createOfferCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOfferCommand updateOfferCommand)
    {
        UpdatedOfferResponse response = await Mediator.Send(updateOfferCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedOfferResponse response = await Mediator.Send(new DeleteOfferCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdOfferResponse response = await Mediator.Send(new GetByIdOfferQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOfferQuery getListOfferQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListOfferListItemDto> response = await Mediator.Send(getListOfferQuery);
        return Ok(response);
    }
}