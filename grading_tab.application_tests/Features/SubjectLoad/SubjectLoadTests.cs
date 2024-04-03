using grading_tab.application.Application.Features.SubjectLoading;
using grading_tab.application.Application.Features.SubjectLoading.Commands.AddSubjectLoad;
using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
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

    [Fact]
    public async Task WhenAddingMeeting_EnsurePersistence_ThenReturnOkay()
    {
        //Arrange
        var meeting = new Meeting(1, 7, 10, DayOfWeek.Saturday);
        const int typeId = 1;
        const int startTime = 7;
        const int endTime = 10;
        const DayOfWeek day = DayOfWeek.Saturday;
        var facultyId = Guid.NewGuid();
        var sectionId = Guid.NewGuid();
        const int subjectId = 1; 
        var createdResult = Guid.NewGuid();
        var meetingId = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<AddSubjectLoadCommand>(),default))
            .Returns(Task.FromResult(createdResult));
        _mediatorMock.Setup(m => m.Send(It.IsAny<AddMeetingCommand>(),default))
            .Returns(Task.FromResult(meetingId));
        
        //Act
        var controller = new SubjectLoadController(_mediatorMock.Object);
        var subjectLoadCreated = await controller.AddSubjectLoad(new AddSubjectLoadModel { FacultyId = facultyId, SectionId = sectionId, SubjectId = subjectId });
        var meetingCreated = await controller.AddMeeting(new AddMeetingModel());
        
        //Assert
        meetingCreated.ShouldBeOfType(typeof(OkObjectResult));
        var objectResult = meetingCreated as OkObjectResult;
        objectResult.ShouldNotBeNull();
        objectResult.Value.ShouldBeEquivalentTo(meetingId);
        objectResult.ShouldNotBe(default);

    }
}