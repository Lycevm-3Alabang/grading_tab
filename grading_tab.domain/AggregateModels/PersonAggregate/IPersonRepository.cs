using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.PersonAggregate
{
    public interface IPersonRepository : IRepository<Person> { 
        Person Create(Person person);
        Person Update(Person person);
        Task<Person?> GetByIdAsync(Guid id);
    }

}
