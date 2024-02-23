using grading_tab.domain.AggregateModels.AssessmentAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.infrastructure.Repositories
{
    public class AssessmentResultRepository : IAssessmentResultRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public AssessmentResult Create(AssessmentResult result)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AssessmentResult>> GetAllAsync()
        {
            throw new NotImplementedException();
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
