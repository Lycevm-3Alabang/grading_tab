using grading_tab.application.Application.Features.Section.Commands.AddSection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace grading_tab.application_tests.Features.Section;

public class SectionsControllerTests
{
    private readonly Mock<IMediator> _mediatorMock = new();

    [Fact]
    public async Task Post_ShouldReturnCreatedStatusCode_WhenCommandSucceeds()
    {
        // Arrange
        var model = new AddSectionModel { Name = "Test Section" };
        Guid? expectedResult = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<AddSectionCommand>(),default))
            .Returns(Task.FromResult(expectedResult));

        var controller = new SectionsController(_mediatorMock.Object);

        // Act
        var result = await controller.AddSection(model);

        // Assert
        result.ShouldBeOfType(typeof(OkObjectResult));
        var objectResult = result as OkObjectResult;
        objectResult.ShouldNotBeNull();
        objectResult.Value.ShouldBeEquivalentTo(expectedResult);
        objectResult.ShouldNotBe(default);
    }

    [Fact]
    public async Task Post_ShouldReturnBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        var controller = new SectionsController(_mediatorMock.Object);
        controller.ModelState.AddModelError("Name", "Name is required");

        // Act
        var result = await controller.AddSection(null);

        // Assert
        result.ShouldBeOfType<BadRequestObjectResult>();
    }
}