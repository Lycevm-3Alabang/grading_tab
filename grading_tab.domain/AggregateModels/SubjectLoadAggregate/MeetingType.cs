using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.SubjectLoadAggregate;

public class MeetingType : Enumeration
{
    public MeetingType(int id, string name) : base(id, name)
    {
        }

    public static IEnumerable<MeetingType> Seed() =>
    [
        new(1,"ASYNCHRONOUS"),
        new(2,"ON-SITE")
    ];
}