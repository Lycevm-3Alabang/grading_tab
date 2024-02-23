using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.infrastructure.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Section Create(Section section)
        {
            throw new NotImplementedException();
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
