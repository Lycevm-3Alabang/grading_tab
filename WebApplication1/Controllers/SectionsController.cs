using System.Net;
using grading_tab.application.Application.Features.Section.Commands.AddSection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        var result = await mediator.Send(new AddSectionCommand(model.Name!));
        return Ok(result);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(Guid),StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(BadRequestObjectResult))]
    public async Task<IActionResult> AddStudent([FromBody] AddStudentModel model)
    {
        var result = await mediator.Send(null);
        return Ok(result);
    }
}