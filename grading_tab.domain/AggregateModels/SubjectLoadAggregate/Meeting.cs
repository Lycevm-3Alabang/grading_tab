using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.FacultyLoadAggregate
{
    public class Meeting : Entity
    {
        private int _typeId;

        public Meeting(int typeId, MeetingType type, int startTime, int endTime, DayOfWeek day)
        {
            _typeId = typeId;
            Type = type;
            StartTime = startTime;
            EndTime = endTime;
            Day = day;
        }

        public MeetingType Type { get; private set; }

        public int StartTime { get; private set; }
        public int EndTime { get; private set; }
        public DayOfWeek Day { get; private set; }
    }

}
