using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.PersonAggregate
{
    public class Person : Entity, IAggregateRoot
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Middlename { get; set; }
        public string? NameSuffix { get; set; }

        public Person() { }
        public Person(string? firstName, string? lastName, string? middlename)
        {
            FirstName = firstName;
            LastName = lastName;
            Middlename = middlename;
        }
        public Person(string? firstName, string? lastName, string? middlename, string? nameSuffix)
        {
            FirstName = firstName;
            LastName = lastName;
            Middlename = middlename;
            NameSuffix = nameSuffix;
        }
    }

}
