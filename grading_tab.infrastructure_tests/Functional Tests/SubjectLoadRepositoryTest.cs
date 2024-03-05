using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using grading_tab.infrastructure;
using grading_tab.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace grading_tab.infrastructure_tests.Functional_Tests;

public class SubjectLoadRepositoryTest
{
    private readonly GradingTabContext _dbContext;
    private static async Task<GradingTabContext> CreateInMemoryDbContext()
    {
        var dbContextOptions = new DbContextOptionsBuilder<GradingTabContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
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
    public async Task WhenCreatingDbContext_EnsureDatabaseSeed()
    {
        // Arrange
        GradingTabContext? context = null;

        //Act
        context = await CreateInMemoryDbContext();

        //Assert
        context.ShouldNotBeNull();
        context.MeetingTypes.ShouldNotBeNull();
        context.MeetingTypes.ShouldNotBeEmpty();
        context.Subjects.ShouldNotBeNull();
        context.Subjects.ShouldNotBeEmpty();
        context.Terms.ShouldNotBeNull();
        context.Terms.ShouldNotBeEmpty();
        context.People.ShouldNotBeNull();
        context.People.ShouldNotBeEmpty();
        context.People.Count().ShouldBe(1);
    }
    
    [Fact]
    public async Task WhenAddingSubjectLoad_EnsureDatabasePersistence()
    {
        //Arrange
        var context = await CreateInMemoryDbContext();
        var faculty = context.People.AsNoTracking().First();
        var section = context.Sections.AsNoTracking().First();
        var repository = new SubjectLoadRepository(context);

        //Act
        var created = repository.Create(new SubjectLoad(faculty.Id, section.Id, Subject.Seed().First().Id));
        await repository.UnitOfWork.SaveEntitiesAsync();
        var result = await repository.GetByIdAsync(created.Id);

        //Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.IsTransient().ShouldBeFalse();
    }
}