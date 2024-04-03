using System.Net;
using grading_tab.application.Application.Features.SubjectLoading;
using grading_tab.application.Application.Features.SubjectLoading.Commands.AddSubjectLoad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
public class SubjectLoadController(IMediator mediator) : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesErrorResponseType(typeof(BadRequestObjectResult))]
    public async Task<IActionResult> AddSubjectLoad([FromBody] AddSubjectLoadModel model)
    {
        var result = await mediator.Send(new AddSubjectLoadCommand(model.FacultyId!.Value, model.SectionId!.Value, model.SubjectId!.Value));
        return Ok(result);
    }
}