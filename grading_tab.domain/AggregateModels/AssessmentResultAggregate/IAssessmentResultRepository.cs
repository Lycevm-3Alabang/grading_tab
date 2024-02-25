using grading_tab.domain.AggregateModels.AssessmentResultAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.AssessmentAggregate
{
    public interface IAssessmentResultRepository : IRepository<AssessmentResult>
    {
        AssessmentResult Create(AssessmentResult result);
        AssessmentResult Update(AssessmentResult result);
        Task<AssessmentResult?> GetByIdAsync(Guid id);
        Task<IEnumerable<AssessmentResult>> GetAllAsync();
    }
}
