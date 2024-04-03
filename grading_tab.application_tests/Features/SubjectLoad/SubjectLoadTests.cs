using grading_tab.application.Application.Features.SubjectLoading;
using grading_tab.application.Application.Features.SubjectLoading.Commands.AddMeeting;
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
        _mediatorMock.Verify(x => x.Send(It.IsAny<AddSubjectLoadCommand>(),It.IsAny<CancellationToken>()),Times.Once);
    }

    [Fact]
    public async Task WhenAddingMeeting_EnsurePersistence_ThenReturnOkay()
    {
        //Arrange
        var facultyId = Guid.NewGuid();
        var sectionId = Guid.NewGuid();
        const int subjectId = 1; 
        var expectedSubjectLoadId = Guid.NewGuid();
        var expectedMeetingId = Guid.NewGuid();
        _mediatorMock.Setup(m => m.Send(It.IsAny<AddSubjectLoadCommand>(),default))
            .Returns(Task.FromResult(expectedSubjectLoadId));
        _mediatorMock.Setup(m => m.Send(It.IsAny<AddMeetingCommand>(),default))
            .Returns(Task.FromResult(expectedMeetingId));
        
        //Act
        var controller = new SubjectLoadController(_mediatorMock.Object);
        var subjectLoadCreated = await controller.AddSubjectLoad(new AddSubjectLoadModel { FacultyId = facultyId, SectionId = sectionId, SubjectId = subjectId });
        var subjectLoadId = (Guid)(subjectLoadCreated as OkObjectResult)!.Value!;
        var meetingCreated = await controller.AddMeeting(subjectLoadId, new AddMeetingModel{ Day = DayOfWeek.Saturday, StartTime = 7, EndTime = 10, MeetingTypeId = 1});
        
        //Assert
        subjectLoadCreated.ShouldBeOfType(typeof(OkObjectResult));
        var subjectLoadResult = subjectLoadCreated as OkObjectResult;
        subjectLoadResult.ShouldNotBeNull();
        subjectLoadResult.Value.ShouldBeEquivalentTo(subjectLoadId);
        subjectLoadResult.Value.ShouldBeEquivalentTo(expectedSubjectLoadId);
        meetingCreated.ShouldBeOfType(typeof(OkObjectResult));
        var objectResult = meetingCreated as OkObjectResult;
        objectResult.ShouldNotBeNull();
        objectResult.Value.ShouldBeEquivalentTo(expectedMeetingId);
        objectResult.ShouldNotBe(default);
        _mediatorMock.Verify(x => x.Send(It.IsAny<AddSubjectLoadCommand>(),It.IsAny<CancellationToken>()),Times.Once);
        _mediatorMock.Verify(x => x.Send(It.IsAny<AddMeetingCommand>(),It.IsAny<CancellationToken>()),Times.Once);
    }
}