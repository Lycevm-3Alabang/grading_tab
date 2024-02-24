using grading_tab.domain.AggregateModels.AssessmentAggregate;
using grading_tab.domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace grading_tab.infrastructure.Repositories
{
    public class AssessmentResultRepository : IAssessmentResultRepository
    {
        public GradingTabContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public AssessmentResultRepository(GradingTabContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AssessmentResult Create(AssessmentResult result)
        {
            return _dbContext.AssessmentResults.Add(result).Entity;
        }

        public async Task<IEnumerable<AssessmentResult>> GetAllAsync()
        {
            return await _dbContext.AssessmentResults
                .Include(x => x.Student)
                .Include(x => x.Subject)
                .Include(x => x.Term)
                .Include(x => x.Type)
                .ToArrayAsync() ?? [];
        }

        public Task<AssessmentResult> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public AssessmentResult Update(AssessmentResult result)
        {
            throw new NotImplementedException();
        }
    }
}
