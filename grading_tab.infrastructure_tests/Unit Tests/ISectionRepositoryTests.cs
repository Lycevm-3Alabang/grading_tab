using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using Moq;
using Shouldly;

namespace grading_tab.infrastructure_tests.Unit_Tests;

public class ISectionRepositoryTests
{
    [Fact]
    public async Task GivenASection_WhenAddedAndSaved_ThenEnsureEntityIsCreated()
    {
        //arrange
        var mockRepository = new Mock<ISectionRepository>();
        var section = new Section("BSCS");
        mockRepository.Setup(x => x.Create(It.IsAny<Section>())).Returns(section);
        mockRepository.Setup(x => x.UnitOfWork.SaveChangesAsync(default)).ReturnsAsync(1);
        
        //act
        var sectionCreated = mockRepository.Object.Create(section);
        var unit = await mockRepository.Object.UnitOfWork.SaveChangesAsync(default);
        
        //assert
        mockRepository.Verify(x => x.Create(section), Times.Once);
        mockRepository.Verify(x => x.UnitOfWork.SaveChangesAsync(default),Times.Once);
        unit.ShouldBe(1);
        section.ShouldNotBeNull();
        section.ShouldBe(sectionCreated);
        section.Name.ShouldBe("BSCS");
    }
    
    [Fact]
    public async Task GivenASection_WhenUpdatedAndSaved_ThenEnsureEntityIsCreated()
    {
        //arrange
        var mockRepository = new Mock<ISectionRepository>();
        var section = new Section("BSCS");
        mockRepository.Setup(x => x.Create(It.IsAny<Section>())).Returns(section);
        mockRepository.Setup(x => x.Update(It.IsAny<Section>())).Returns(section);
        mockRepository.Setup(x => x.UnitOfWork.SaveChangesAsync(default)).ReturnsAsync(1);
        
        //act
        mockRepository.Object.Create(section);
        var unit = await mockRepository.Object.UnitOfWork.SaveChangesAsync(default);
        var sectionUpdated = mockRepository.Object.Update(section);
        await mockRepository.Object.UnitOfWork.SaveChangesAsync(default);
        
        //assert
        mockRepository.Verify(x => x.Create(section), Times.Once);
        mockRepository.Verify(x => x.Update(sectionUpdated), Times.Once);
        mockRepository.Verify(x => x.UnitOfWork.SaveChangesAsync(default),Times.Exactly(2));
        unit.ShouldBe(1);
        section.ShouldBe(sectionUpdated);
    }
}