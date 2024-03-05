using grading_tab.domain.AggregateModels.AssessmentResultAggregate;
using grading_tab.domain.AggregateModels.PersonAggregate;
using Moq;
using Shouldly;

namespace grading_tab.infrastructure_tests.Unit_Tests;

public class IPersonRepositoryTests
{
    [Fact]
    public async Task GivenAnAssessmentResult_WhenAddedAndSaved_ThenEnsureEntityIsCreated()
    {
        //arrange
        var mockRepository = new Mock<IPersonRepository>();
        var person = new Person("John", "Krasinski", "Wick");
        mockRepository.Setup(x => x.Create(It.IsAny<Person>())).Returns(person);
        mockRepository.Setup(x => x.UnitOfWork.SaveChangesAsync(default)).ReturnsAsync(1);
        
        //act
        var personCreated = mockRepository.Object.Create(person);
        var unit = await mockRepository.Object.UnitOfWork.SaveChangesAsync(default);
        
        //assert
        mockRepository.Verify(x => x.Create(person), Times.Once);
        mockRepository.Verify(x => x.UnitOfWork.SaveChangesAsync(default),Times.Once);
        unit.ShouldBe(1);
        person.ShouldBe(personCreated);
        personCreated.FirstName.ShouldBe("John");
        personCreated.Middlename.ShouldBe("Wick");
        personCreated.LastName.ShouldBe("Krasinski");

    }
    
    [Fact]
    public async Task GivenAnAssessmentResult_WhenUpdatedAndSaved_ThenEnsureEntityIsCreated()
    {
        //arrange
        var mockRepository = new Mock<IPersonRepository>();
        var person = new Person("John", "Krasinski", "Wick");
        mockRepository.Setup(x => x.Create(It.IsAny<Person>())).Returns(person);
        mockRepository.Setup(x => x.Update(It.IsAny<Person>())).Returns(person);
        mockRepository.Setup(x => x.UnitOfWork.SaveChangesAsync(default)).ReturnsAsync(1);
        
        //act
        mockRepository.Object.Create(person);
        var unit = await mockRepository.Object.UnitOfWork.SaveChangesAsync(default);
        var personUpdated = mockRepository.Object.Update(person);
        await mockRepository.Object.UnitOfWork.SaveChangesAsync(default);
        
        //assert
        mockRepository.Verify(x => x.Create(person), Times.Once);
        mockRepository.Verify(x => x.Update(personUpdated), Times.Once);
        mockRepository.Verify(x => x.UnitOfWork.SaveChangesAsync(default),Times.Exactly(2));
        unit.ShouldBe(1);
        person.ShouldBe(personUpdated);
        personUpdated.FirstName.ShouldBe(person.FirstName);
        personUpdated.Middlename.ShouldBe(person.Middlename);
        personUpdated.LastName.ShouldBe(person.LastName);

    }
}