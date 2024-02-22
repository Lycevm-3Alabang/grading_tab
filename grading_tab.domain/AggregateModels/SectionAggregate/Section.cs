using grading_tab.domain.SeedWork;
using System.Collections.ObjectModel;

namespace grading_tab.domain.AggregateModels.SectionAggregate
{
    public class Section : Entity, IAggregateRoot
    {
        public string? Name { get; private set; }

        private List<Student>? _students;
        public ReadOnlyCollection<Student> Students => _students.AsReadOnly();


        private Section()
        {
            _students = new List<Student>();
        }

        public Section(string? name) : this() { }
        
    }

    public interface ISectionRepository : IRepository<Section>
    {
        Section Create(Section section);
        Section Update(Section section);

    }
    
}
