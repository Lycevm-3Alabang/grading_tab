using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.infrastructure.Repositories
{
    public class SectionRepository(GradingTabContext dbContext) : ISectionRepository
    {
        private readonly GradingTabContext _dbContext = dbContext;

        public IUnitOfWork UnitOfWork => _dbContext;

        public Section Create(Section section)
        {
            return null;
        }

        public Task<Section> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Section Update(Section section)
        {
            throw new NotImplementedException();
        }
    }
}
