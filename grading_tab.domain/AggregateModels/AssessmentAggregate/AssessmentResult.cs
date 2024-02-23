
using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.AssessmentAggregate
{
    public class AssessmentResult : Entity, IAggregateRoot
    {
        public DateTimeOffset AssessmentDate { get; private set; }
        public int Score { get; private set; }
        public int TotalItems { get; private set; }
        public decimal Grade { get; private set; }

        private int _assessmentTypeId;
        public AssessmentType? AssessmentType { get; private set; }

        private Guid? _studentId;
        public Person? Student { get; private set; }

        public int _gradingPeriodId;
        public Term? GradingPeriod { get; private set;}

        public int _subjectId;
        public Subject? Subject { get; private set; }

        public AssessmentResult()
        {
            
        }

        public AssessmentResult(DateTimeOffset assessmentDate, int score, int totalItems, decimal grade, int assessmentTypeId, Guid studentId, int gradingPeriodId, int subjectId)
        {
            AssessmentDate = assessmentDate;
            Score = score;
            _assessmentTypeId = assessmentTypeId;
            _studentId = studentId;
            _gradingPeriodId = gradingPeriodId;
            _subjectId = subjectId;
            TotalItems = totalItems;
            Grade = grade;
        }
    }
}
