using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.infrastructure.Repositories
{
    public class PersonRepository(GradingTabContext dbContext) : IPersonRepository
    {
        public IUnitOfWork UnitOfWork => dbContext;

        public Person Create(Person person)
        {
            return dbContext.People.Add(person).Entity;
        }

        public async Task<Person?> GetByIdAsync(Guid id)
        {
            return await dbContext.People.FindAsync(id);
        }

        public Person Update(Person person)
        {
            return dbContext.People.Update(person).Entity;
        }
    }
}
