using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.SectionAggregate
{
    public class Student : Entity
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Middlename { get; private set; }
        public string? Number { get; private set; }

        private Student() { }

        public Student(string? firstName, string? lastName, string? middlename, string? number)
        {
            FirstName = firstName;
            LastName = lastName;
            Middlename = middlename;
            Number = number;
        }
    }
    
}
