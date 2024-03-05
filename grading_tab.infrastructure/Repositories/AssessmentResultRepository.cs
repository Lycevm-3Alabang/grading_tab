using grading_tab.domain.AggregateModels.AssessmentAggregate;
using grading_tab.domain.AggregateModels.AssessmentResultAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.infrastructure.Repositories
{
    public class AssessmentResultRepository(GradingTabContext dbContext) : IAssessmentResultRepository
    {
        public IUnitOfWork UnitOfWork => dbContext;

        public AssessmentResult Create(AssessmentResult result)
        {
            return dbContext.AssessmentResults.Add(result).Entity;
        }

        public async Task<IEnumerable<AssessmentResult>> GetAllAsync()
        {
            return await dbContext.AssessmentResults
                .Include(x => x.Student)
                .Include(x => x.Subject)
                .Include(x => x.Term)
                .Include(x => x.Type)
                .ToArrayAsync() ?? [];
        }

        public async Task<AssessmentResult?> GetByIdAsync(Guid id)
        {
            return await dbContext.AssessmentResults
                .Include(x => x.Subject)
                .Include(x => x.Type)
                .Include(x => x.Term)
                .Include(x => x.Student)
                .SingleOrDefaultAsync();
        }

        public AssessmentResult Update(AssessmentResult result)
        {
            return dbContext.AssessmentResults.Update(result).Entity;
        }
    }
}
