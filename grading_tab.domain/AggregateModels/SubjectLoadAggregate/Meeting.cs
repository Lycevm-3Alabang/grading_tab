using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.FacultyLoadAggregate
{
    public class Meeting : Entity
    {
        private int _typeId;

        public Meeting(int typeId, int startTime, int endTime, DayOfWeek day)
        {
            _typeId = typeId;
            StartTime = startTime;
            EndTime = endTime;
            Day = day;
        }
        protected Meeting() { }

        public MeetingType Type { get; private set; }

        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public DayOfWeek Day { get; private set; }

        public int GetMeetingTypeId() => Type?.Id ?? _typeId;
        public void SetMeetingType(int id) => _typeId = id;
    }

}
