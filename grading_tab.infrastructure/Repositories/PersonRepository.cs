using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Person Create(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
