using System.Collections.ObjectModel;
using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.AggregateModels.SectionAggregate;
using grading_tab.domain.Exceptions;
using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.SubjectLoadAggregate
{
    public class SubjectLoad : Entity, IAggregateRoot
    {
        private Guid _sectionId;
        private int _subjectId;
        private Guid _facultyId;
        private List<Meeting>? _meetings;


        public Section? Section { get; private set; }
        public Subject? Subject { get; private set; }
        public Person? Faculty { get; private set; }
        public IEnumerable<Meeting> Meetings => _meetings!.AsReadOnly();
        

        public SubjectLoad(Guid facultyId, Guid sectionId, int subjectId) : base()
        {
            _facultyId = facultyId;
            _sectionId = sectionId;
            _subjectId = subjectId;
        }

        protected SubjectLoad()
        {
            _meetings = [];
        }

        public void AddMeeting(Meeting meeting)
        {
            if (_meetings == null) _meetings = [];
            if (_meetings.Count < 2)
            {
                _meetings.Add(meeting);
            }

            throw new MeetingOverTheLimitException();
        }

        public void RemoveMeeting(Meeting meeting)
        {
            _meetings!.Remove(meeting);
        }

        public void SetFaculty(Guid id) => _facultyId = id;
        public void SetSubject(int id) => _subjectId = id;
        public void SetSection(Guid id) => _sectionId = id;
        
    }
    
}
