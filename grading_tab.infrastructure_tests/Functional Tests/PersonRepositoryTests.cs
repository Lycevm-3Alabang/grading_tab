using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.infrastructure;
using grading_tab.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace grading_tab.infrastructure_tests.Functional_Tests;

public class PersonRepositoryTests
{
    private static async Task<GradingTabContext> CreateInMemoryDbContext()
    {
        var dbContextOptions = new DbContextOptionsBuilder<GradingTabContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var sharedContext = new GradingTabContext(dbContextOptions);
        await sharedContext.Database.EnsureDeletedAsync();
        await sharedContext.Database.EnsureCreatedAsync();
        await sharedContext.SaveChangesAsync(default);
        return sharedContext;
    }
    
    [Fact]
    public async Task WhenAddingPerson_EnsureDatabasePersistence()
    {
        //Arrange
        var context = await CreateInMemoryDbContext();
        var repository = new PersonRepository(context);

        //Act
        var created = repository.Create(new Person("John","Krasinski","Wick"));
        await repository.UnitOfWork.SaveChangesAsync(default);
        var result = await repository.GetByIdAsync(created.Id);

        //Assert
        result.ShouldNotBeNull();
        result.Id.ShouldBe(created.Id);
        result.IsTransient().ShouldBeFalse();
        result.FirstName.ShouldBe(created.FirstName);
        result.Middlename.ShouldBe(created.Middlename);
        result.LastName.ShouldBe(created.LastName);
        created.FirstName.ShouldBe("John");
        created.Middlename.ShouldBe("Wick");
        created.LastName.ShouldBe("Krasinski");
    }
}