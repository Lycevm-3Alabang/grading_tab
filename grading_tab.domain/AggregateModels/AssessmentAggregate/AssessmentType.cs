
using grading_tab.domain.AggregateModels.SectionAggregate;
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

    public class GradingPeriod : Enumeration
    {
        public GradingPeriod(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<GradingPeriod> Seed() => 
            [
                new(1,"PRELIM"),
                new(2,"MIDTERM"),
                new(3,"PREFINAL"),
                new(4,"FINAL"),
            ];
    }

    public class Assessment : Entity
    {
        public DateTimeOffset AssessmentDate { get; private set; }
        public decimal Score { get; private set; }

        private int _assessmentTypeId;
        public AssessmentType AssessmentType { get; private set; }

        private Guid _studentId;
        public Student Student { get; private set; }

        public int _gradingPeriodId;
        public GradingPeriod GradingPeriod { get; private set;}
    }
}
