using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.SectionAggregate
{
    public interface ISectionRepository : IRepository<Section>
    {
        Section Create(Section section);
        Section Update(Section section);
        Task<Section> GetByIdAsync(Guid id);
    }
    
}
