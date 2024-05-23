using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.SubjectLoadAggregate;

public interface ISubjectLoadRepository : IRepository<SubjectLoad>
{
    SubjectLoad Create(SubjectLoad subjectLoad);
    SubjectLoad Update(SubjectLoad subjectLoad);
    Task<SubjectLoad?> GetByIdAsync(Guid id);
    Task<IEnumerable<SubjectLoad>> GetAllAsync();

}