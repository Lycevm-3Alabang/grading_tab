using grading_tab.domain.AggregateModels.AssessmentAggregate;
using grading_tab.domain.AggregateModels.AssessmentResultAggregate;
using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using grading_tab.infrastructure;
using grading_tab.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace grading_tab.infrastructure_tests.Functional_Tests;

public class AssessmentResultRepositoryTest
{
    private static async Task<GradingTabContext> CreateInMemoryDbContext()
    {
        var dbContextOptions = new DbContextOptionsBuilder<GradingTabContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var sharedContext = new GradingTabContext(dbContextOptions);
        await sharedContext.Database.EnsureDeletedAsync();
        await sharedContext.Database.EnsureCreatedAsync();

        var person = new Person("John", "Krasinski", "Wick","");
        var section = new Section("BSCS-XXXX");
        var student = new Student("1234-56", "BS Computer Science", person);
        section.AddStudent(student);
        sharedContext.Sections.Add(section);
        
        await sharedContext.SaveChangesAsync(default);
        return sharedContext;
    }
    
    [Fact]
    public async Task WhenAddingAssessmentResult_EnsureDatabasePersistence()
    {
        //Arrange
        var context = await CreateInMemoryDbContext();
        var faculty = context.People.AsNoTracking().First();
        var section = context.Sections.AsNoTracking().First();
        var repository = new AssessmentResultRepository(context);

        //Act
        var created = repository.Create(new AssessmentResult(
            DateTimeOffset.Now,
            10,
            10,
            100,
            AssessmentType.Seed().First().Id,
            context.Students.AsNoTracking().First().Id,
            Term.Seed().First().Id,
            Subject.Seed().First().Id));
        await repository.UnitOfWork.SaveChangesAsync(default);
        var result = await repository.GetByIdAsync(created.Id);

        //Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.IsTransient().ShouldBeFalse();
        result.Type.ShouldNotBeNull();
        result.Type.Name.ShouldBe(AssessmentType.Seed().First().Name);
        result.Type.Id.ShouldBe(AssessmentType.Seed().First().Id);
        result.Subject.ShouldBe(Subject.Seed().First());
        result.Term.ShouldBe(Term.Seed().First());
    }
}