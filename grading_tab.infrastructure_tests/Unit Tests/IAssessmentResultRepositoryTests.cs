using grading_tab.domain.AggregateModels.AssessmentAggregate;
using grading_tab.domain.AggregateModels.AssessmentResultAggregate;
using grading_tab.infrastructure.Repositories;
using Moq;
using Shouldly;

namespace grading_tab.infrastructure_tests.Unit_Tests;

public class IAssessmentResultRepositoryTests
{
    [Fact]
    public async Task GivenAnAssessmentResult_WhenAddedAndSaved_ThenEnsureEntityIsCreated()
    {
        //arrange
        var mockRepository = new Mock<IAssessmentResultRepository>();
        var assessmentResult = new AssessmentResult(DateTimeOffset.Now, 10, 10, 100, 1, Guid.NewGuid(), 1, 1);
        mockRepository.Setup(x => x.Create(It.IsAny<AssessmentResult>())).Returns(assessmentResult);
        mockRepository.Setup(x => x.UnitOfWork.SaveChangesAsync(default)).ReturnsAsync(1);
        
        //act
        var assessmentresultCreated = mockRepository.Object.Create(assessmentResult);
        var unit = await mockRepository.Object.UnitOfWork.SaveChangesAsync(default);
        
        //assert
        mockRepository.Verify(x => x.Create(assessmentResult), Times.Once);
        mockRepository.Verify(x => x.UnitOfWork.SaveChangesAsync(default),Times.Once);
        unit.ShouldBe(1);
        assessmentResult.ShouldBe(assessmentresultCreated);
        assessmentresultCreated.TotalItems.ShouldBe(10);
        assessmentresultCreated.Score.ShouldBe(10);
        assessmentresultCreated.Grade.ShouldBe(assessmentResult.Grade);
    }
}