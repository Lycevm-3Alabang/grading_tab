using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.AssessmentAggregate
{
    public class Term : Enumeration
    {
        public Term(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<Term> Seed() => 
            [
                new(1,"PRELIM"),
                new(2,"MIDTERM"),
                new(3,"PREFINAL"),
                new(4,"FINAL"),
            ];
    }
}
