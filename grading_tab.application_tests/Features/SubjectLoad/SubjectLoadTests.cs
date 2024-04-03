using grading_tab.application.Application.Features.SubjectLoading;
using grading_tab.application.Application.Features.SubjectLoading.Commands.AddSubjectLoad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace grading_tab.application_tests.Features.SubjectLoad;

public class SubjectLoadTests
{
    private readonly Mock<IMediator> _mediatorMock = new();

    [Fact]
    public async Task Post_ShouldReturnCreatedStatusCode_WhenCommandSucceeds()
    {
        // Arrange
        var facultyId = Guid.NewGuid();
        var sectionId = Guid.NewGuid();
        const int subjectId = 1;
        var expectedResult = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<AddSubjectLoadCommand>(),default))
            .Returns(Task.FromResult(expectedResult));

        // Act
        var controller = new SubjectLoadController(_mediatorMock.Object);
        var result = await controller.AddSubjectLoad(new AddSubjectLoadModel { FacultyId = facultyId, SectionId = sectionId, SubjectId = subjectId });

        // Assert
        result.ShouldBeOfType(typeof(OkObjectResult));
        var objectResult = result as OkObjectResult;
        objectResult.ShouldNotBeNull();
        objectResult.Value.ShouldBeEquivalentTo(expectedResult);
        objectResult.ShouldNotBe(default);
    }
}