using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.infrastructure.Repositories
{
    public class SubjectLoadRepository : ISubjectLoadRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public SubjectLoad Create(SubjectLoad section)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubjectLoad>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SubjectLoad> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public SubjectLoad Update(SubjectLoad section)
        {
            throw new NotImplementedException();
        }
    }
}
