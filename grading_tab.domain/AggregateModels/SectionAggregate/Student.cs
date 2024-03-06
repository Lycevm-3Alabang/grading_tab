using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.SectionAggregate;

public class Student : Entity
{
    public string? Number { get; set; }
    public string? Course { get; set; }
    private Guid _personId;
    public Person Person { get; private set; }

    public Student(string? number,string? course, Person person)
    {
        Number = number;
        Course = course;
        Person = person;
    }
        
    public Student(string? number,string? course, Guid personId)
    {
        Number = number;
        Course = course;
        _personId = personId;
    }

    public Student(string? number, string? course)
    {
        Number = number;
        Course = course;
    }
        
    protected Student(){}

    public void SetPerson(Person person) => Person = person;
}