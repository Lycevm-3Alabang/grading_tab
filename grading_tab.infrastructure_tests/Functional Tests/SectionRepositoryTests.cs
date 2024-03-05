using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.infrastructure;
using grading_tab.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace grading_tab.infrastructure_tests.Functional_Tests;

public class SectionRepositoryTests
{
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

        sharedContext.People.Add(new Person("Ryan", "Gosling", ""));

        await sharedContext.SaveChangesAsync(default);
        return sharedContext;
    }
    
    [Fact]
    public async Task WhenAddingSection_EnsureDatabasePersistence()
    {
        //Arrange
        var context = await CreateInMemoryDbContext();
        var repository = new SectionRepository(context);

        //Act
        var created = repository.Create(new Section("BSCS"));
        await repository.UnitOfWork.SaveEntitiesAsync();
        var result = await repository.GetByIdAsync(created.Id);

        //Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.IsTransient().ShouldBeFalse();
    }

    [Fact]
    public async Task WhenAddingStudent_EnsureSectionPersistsWithStudentRecord()
    {
        var context = await CreateInMemoryDbContext();
        var repository = new SectionRepository(context);
        var sectionId = ((await context.Sections.AsNoTracking().FirstOrDefaultAsync())!).Id;
        var person = await context.People.AsNoTracking().FirstOrDefaultAsync(x => x.LastName == "Gosling");
        var student = new Student("9999-99", "BSIT", person.Id);

        var updated = await repository.GetByIdAsync(sectionId);
        updated?.AddStudent(student);
        var unit = await repository.UnitOfWork.SaveChangesAsync(default);

        person.ShouldNotBeNull();
        
        updated.ShouldNotBeNull();
        updated.Students.Any().ShouldBeTrue();
        updated.Students.Count().ShouldBe(2);
        updated.Students.ShouldContain(student);
        updated.Students.Any(i => i.Person.Id == person.Id).ShouldBeTrue();
        var addedStudent = updated.Students.FirstOrDefault(x => x.Id == student.Id);
        addedStudent.ShouldBe(student);
        addedStudent!.Number.ShouldBe("9999-99");
        addedStudent.Course.ShouldBe("BSIT");
        addedStudent.Person.LastName.ShouldBe("Gosling");
        addedStudent.Person.FirstName.ShouldBe("Ryan");
        unit.ShouldBe(1);
    }
}