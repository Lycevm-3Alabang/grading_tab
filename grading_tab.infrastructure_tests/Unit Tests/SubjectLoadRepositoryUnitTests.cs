using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using Moq;
using Shouldly;

namespace grading_tab.infrastructure_tests.Unit_Tests;

public class SubjectLoadRepositoryUnitTests
{
    [Fact]
    public void GivenASubjectLoad_WhenAddedAndSaved_ThenEnsureEntityIsCreated()
    {
        //Arrange
        var mockRepository = new Mock<ISubjectLoadRepository>();
        var subjectLoad = new SubjectLoad(Guid.NewGuid(), Guid.NewGuid(), 1);
        mockRepository.Setup(x => x.Create(It.IsAny<SubjectLoad>())).Returns(subjectLoad);
        mockRepository.Setup(x => x.UnitOfWork.SaveChangesAsync(default)).ReturnsAsync(It.IsAny<int>());

        //Act
        var createdSubjectLoad = mockRepository.Object.Create(subjectLoad);
        mockRepository.Object.UnitOfWork.SaveChangesAsync(default);

        //Assert
        mockRepository.Verify(x => x.Create(subjectLoad),Times.Once);
        mockRepository.Verify(c => c.UnitOfWork.SaveChangesAsync(default),Times.Once);
    }
    
    [Fact]
    public async Task GivenASubjectLoad_WhenUpdatedAndSaved_ThenEnsureEntityIsCreated()
    {
        //Arrange
        var subjectLoad = new SubjectLoad(Guid.NewGuid(), Guid.NewGuid(), 1);
        var mockRepository = new Mock<ISubjectLoadRepository>();
        mockRepository.Setup(x => x.Create(It.IsAny<SubjectLoad>())).Returns(subjectLoad);
        mockRepository.Setup(x => x.UnitOfWork.SaveChangesAsync(default)).ReturnsAsync(It.IsAny<int>());
        mockRepository.Setup(x => x.Update(It.IsAny<SubjectLoad>())).Returns(subjectLoad);

        //Act
        mockRepository.Object.Create(subjectLoad);
        await mockRepository.Object.UnitOfWork.SaveChangesAsync(default);
        var meeting = new Meeting(1, 7, 10, DayOfWeek.Saturday);
        subjectLoad.AddMeeting(meeting);
        var updatedSubjectLoad = mockRepository.Object.Update(subjectLoad);
        await mockRepository.Object.UnitOfWork.SaveChangesAsync(default);

        //Assert
        subjectLoad.Meetings.Count().ShouldBe(1);
        updatedSubjectLoad.ShouldBe(subjectLoad);
        updatedSubjectLoad.Id.ShouldBe(subjectLoad.Id);
        updatedSubjectLoad.Meetings.ShouldContain(meeting);
        updatedSubjectLoad.Meetings.Count().ShouldBe(1);
        updatedSubjectLoad.Meetings.First().Day.ShouldBe(DayOfWeek.Saturday);
        updatedSubjectLoad.Meetings.First().EndTime.ShouldBe(meeting.EndTime);
        updatedSubjectLoad.Meetings.First().StartTime.ShouldBe(meeting.StartTime);
        updatedSubjectLoad.Meetings.First().ShouldBe(meeting);
        mockRepository.Verify(x => x.Create(subjectLoad),Times.Once);
        mockRepository.Verify(x => x.Update(subjectLoad),Times.Once);
        mockRepository.Verify(c => c.UnitOfWork.SaveChangesAsync(default),Times.AtLeast(2));
    }
}