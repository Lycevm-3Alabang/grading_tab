using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SectionsController(IMediator mediator) : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(Guid),StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(BadRequestObjectResult))]
    public async Task<IActionResult> AddSection([FromBody] AddSectionModel model)
    {
        var result = await mediator.Send(model.ToCommand());
        return Ok(result);
    }
    
    [HttpPost("{id}/students")]
    [ProducesResponseType(typeof(Guid),StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(BadRequestObjectResult))]
    public async Task<IActionResult> AddStudent(Guid id, [FromBody] AddStudentModel model)
    {
        var result = await mediator.Send(model.ToCommand(id));
        return Ok(result);
    }
}