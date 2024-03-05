using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.infrastructure.Repositories
{
    public class SectionRepository(GradingTabContext dbContext) : ISectionRepository
    {
        public IUnitOfWork UnitOfWork => dbContext;

        public Section Create(Section section) => dbContext.Sections.Add(section).Entity;

        public async Task<Section?> GetByIdAsync(Guid id) =>
            await dbContext.Sections
                .Include(x => x.Students)
                .FirstOrDefaultAsync(x => x.Id == id); 

        public Section Update(Section section) => dbContext.Sections.Add(section).Entity;
    }
}
