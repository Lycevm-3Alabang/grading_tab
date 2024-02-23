using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.SectionAggregate
{
    public interface ISubjectLoadRepository : IRepository<SubjectLoad>
    {
        SubjectLoad Create(SubjectLoad section);
        SubjectLoad Update(SubjectLoad section);
        Task<SubjectLoad> GetByIdAsync(Guid id);
        Task<IEnumerable<SubjectLoad>> GetAllAsync();
    }
    
}
