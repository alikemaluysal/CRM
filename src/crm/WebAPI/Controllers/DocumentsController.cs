using Application.Features.Documents.Commands.Create;
using Application.Features.Documents.Commands.Delete;
using Application.Features.Documents.Commands.Update;
using Application.Features.Documents.Queries.GetById;
using Application.Features.Documents.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateDocumentCommand createDocumentCommand)
    {
        CreatedDocumentResponse response = await Mediator.Send(createDocumentCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDocumentCommand updateDocumentCommand)
    {
        UpdatedDocumentResponse response = await Mediator.Send(updateDocumentCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedDocumentResponse response = await Mediator.Send(new DeleteDocumentCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdDocumentResponse response = await Mediator.Send(new GetByIdDocumentQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDocumentQuery getListDocumentQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListDocumentListItemDto> response = await Mediator.Send(getListDocumentQuery);
        return Ok(response);
    }
}