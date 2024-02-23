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
                new Term(1,"PRELIM"),
                new Term(2,"MIDTERM"),
                new Term(3,"PRE-FINAL"),
                new Term(4,"FINAL"),
            ];
    }
}
