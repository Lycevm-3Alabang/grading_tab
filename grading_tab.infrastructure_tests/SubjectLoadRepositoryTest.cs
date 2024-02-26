using grading_tab.domain.AggregateModels.AssessmentAggregate;
using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using grading_tab.infrastructure;
using grading_tab.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;


namespace grading_tab.infrastructure_tests;

public class SubjectLoadRepositoryTest
{
    private async Task<GradingTabContext> CreateInMemoryDbContext()
    {
        var dbContextOptions = new DbContextOptionsBuilder<GradingTabContext>()
            .UseInMemoryDatabase(databaseName: "in-memory")
            .Options;
        var sharedContext = new GradingTabContext(dbContextOptions);
        await sharedContext.Database.EnsureDeletedAsync();
        await sharedContext.Database.EnsureCreatedAsync();

        var person = new Person("John", "Krasinski", "Wick");
        var section = new Section("BSCS-XXXX");
        var student = new Student("1234-56", "BS Computer Science", person);
        section.AddStudent(student);
        sharedContext.Sections.Add(section);

        await sharedContext.SaveChangesAsync(default);
        return sharedContext;
    }
    
    [Fact]
    public async Task TestDbContext()
    {
        // Arrange
        var context =  await CreateInMemoryDbContext();

        //Assert
        Assert.NotNull(context);
        Assert.True(context.MeetingTypes.Any());
        Assert.True(context.Subjects.Any());
        Assert.True(context.Terms.Any());
        Assert.True(context.People.Any());
        Assert.Equal(1, context.People.Count());
    }
    
    [Fact]
    public async Task WhenCreatingANewSubject_EnsurePersistence()
    {
        //Arrange
        var context = await CreateInMemoryDbContext();
        var repository = new SubjectLoadRepository(context);
        

        //Act
        var created = repository.Create(new SubjectLoad(Guid.NewGuid(), Guid.NewGuid(), 1));
        await repository.UnitOfWork.SaveEntitiesAsync();
        var result = await repository.GetByIdAsync(created.Id);

        //Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
    }
}