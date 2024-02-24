using Application.Features.DocumentTypes.Commands.Create;
using Application.Features.DocumentTypes.Commands.Delete;
using Application.Features.DocumentTypes.Commands.Update;
using Application.Features.DocumentTypes.Queries.GetById;
using Application.Features.DocumentTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateDocumentTypeCommand createDocumentTypeCommand)
    {
        CreatedDocumentTypeResponse response = await Mediator.Send(createDocumentTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDocumentTypeCommand updateDocumentTypeCommand)
    {
        UpdatedDocumentTypeResponse response = await Mediator.Send(updateDocumentTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedDocumentTypeResponse response = await Mediator.Send(new DeleteDocumentTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdDocumentTypeResponse response = await Mediator.Send(new GetByIdDocumentTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDocumentTypeQuery getListDocumentTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListDocumentTypeListItemDto> response = await Mediator.Send(getListDocumentTypeQuery);
        return Ok(response);
    }
}