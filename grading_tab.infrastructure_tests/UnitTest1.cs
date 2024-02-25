using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using grading_tab.domain.SeedWork;
using grading_tab.infrastructure;
using grading_tab.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace grading_tab.infrastructure_tests;

public class SubjectLoadRepositoryTest
{
    private Mock<GradingTabContext> _mockDbContext;
    private SubjectLoadRepository _repository;
    private DbContextOptions<GradingTabContext> options;

    public SubjectLoadRepositoryTest()
    {
        options = new DbContextOptionsBuilder<GradingTabContext>()
            .UseInMemoryDatabase(databaseName: "test_db")
            .Options;
        _repository = new SubjectLoadRepository(new GradingTabContext(options));
    }
    
    [Fact]
    public void Create_ShouldAddSubjectLoad_AndSaveChanges()
    {
        // Arrange
        var subjectLoad = new SubjectLoad(Guid.NewGuid(), Guid.NewGuid(), 1);

        // Act
        var addedSubjectLoad = _repository.Create(subjectLoad);

        // Assert
        Assert.NotNull(addedSubjectLoad);
        // Additional assertions based on your implementation
    }
}