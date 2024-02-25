using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.infrastructure.Repositories
{
    public class SubjectLoadRepository : ISubjectLoadRepository
    {
        public IUnitOfWork UnitOfWork => _dbContext;
        private readonly GradingTabContext _dbContext;

        public SubjectLoadRepository(GradingTabContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SubjectLoad Create(SubjectLoad subjectLoad)
        {
            return _dbContext.SubjectLoads.Add(subjectLoad).Entity;
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
