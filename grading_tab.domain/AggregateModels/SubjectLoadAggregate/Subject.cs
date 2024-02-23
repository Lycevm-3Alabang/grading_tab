using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.SectionAggregate
{
    public class Subject : Enumeration
    {
        public Subject(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<Subject> Seed() =>
            [
                new(1,"CE ELECTIVE 2"),
                new(2,"IT ELECTIVE 3"),
            ];
    }
    
}
