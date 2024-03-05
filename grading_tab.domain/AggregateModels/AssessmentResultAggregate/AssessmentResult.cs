using grading_tab.domain.AggregateModels.AssessmentAggregate;
using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.domain.AggregateModels.SubjectLoadAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.AssessmentResultAggregate
{
    public class AssessmentResult : Entity, IAggregateRoot
    {
        public DateTimeOffset AssessmentDate { get; private set; }
        public int Score { get; private set; }
        public int TotalItems { get; private set; }
        public decimal Grade { get; private set; }

        private int _typeId;
        public AssessmentType? Type { get; private set; }

        private Guid _studentId;
        public Student? Student { get; private set; }

        public int _termId;
        public Term? Term { get; private set;}

        public int _subjectId;
        public Subject? Subject { get; private set; }

        public AssessmentResult()
        {
            
        }

        public AssessmentResult(DateTimeOffset assessmentDate, int score, int totalItems, decimal grade, int typeId, Guid studentId, int termId, int subjectId)
        {
            AssessmentDate = assessmentDate;
            Score = score;
            _typeId = typeId;
            _studentId = studentId;
            _termId = termId;
            _subjectId = subjectId;
            TotalItems = totalItems;
            Grade = grade;
        }
    }
}
