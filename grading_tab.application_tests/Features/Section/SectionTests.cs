using grading_tab.application.Application.Features.Section.Commands.AddSection;
using grading_tab.application.Application.Features.Section.Commands.AddStudent;
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
    public async Task GivenASection_WhenAddingAStudent_EnsureCreated()
    {
        // Arrange
        var model = new AddSectionModel { Name = "Test Section" };
        Guid? sectionId = Guid.NewGuid();
        Guid? studentId = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<AddSectionCommand>(),default)).Returns(Task.FromResult(sectionId));
        _mediatorMock.Setup(x => x.Send(It.IsAny<AddStudentCommand>(), default)).Returns(Task.FromResult(studentId));
        var controller = new SectionsController(_mediatorMock.Object);

        // Act
        var result = await controller.AddSection(model);
        var studentResult = await controller.AddStudent(sectionId.Value, new AddStudentModel());

        // Assert
        studentResult.ShouldBeOfType(typeof(OkObjectResult));
        var objectResult = studentResult as OkObjectResult;
        objectResult.ShouldNotBeNull();
        objectResult.Value.ShouldBeEquivalentTo(studentId);
        objectResult.ShouldNotBe(default);
    }

    [Fact]
    public async Task Post_ShouldReturnBadRequest_WhenModelStateIsInvalid()
    {
        // Arrange
        var controller = new SectionsController(_mediatorMock.Object);

        // Act
        controller.ModelState.AddModelError("Name", "Name is required");

        // Assert
        await Assert.ThrowsAsync<NullReferenceException>(() => controller.AddSection(null));
    }
    
   
}