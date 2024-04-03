using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.SubjectLoadAggregate
{
    public class Meeting : Entity
    {
        private int _typeId;

        public Meeting(int typeId, DateTimeOffset startTime, DateTimeOffset endTime, DayOfWeek day)
        {
            _typeId = typeId;
            StartTime = startTime;
            EndTime = endTime;
            Day = day;
        }
        protected Meeting() { }

        public MeetingType Type { get; private set; }

        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public DayOfWeek Day { get; private set; }

        public int GetMeetingTypeId() => Type?.Id ?? _typeId;
        public void SetMeetingType(int id) => _typeId = id;
    }

}
