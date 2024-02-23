using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.AssessmentAggregate
{
    public class AssessmentType : Enumeration
    {
        public AssessmentType(int id, string name) : base(id, name)
        {
        }

        public decimal Percentage { get; private set; }

        public static IEnumerable<AssessmentType> Seed() =>
            [
                new (1,"Attendance"),
                new (2,"Participation"),
                new (3,"Assignment"),
                new (4,"Project - Completion"),
                new (5,"Project - Delivery"),
                new (6,"Major Exam")
            ];
        
    }
}
