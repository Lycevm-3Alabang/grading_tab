using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.SeedWork;
using System.Collections.ObjectModel;

namespace grading_tab.domain.AggregateModels.SectionAggregate
{
    public class Section : Entity, IAggregateRoot
    {
        public string? Name { get; private set; }

        private List<Person>? _students;
        public ReadOnlyCollection<Person> Students => _students!.AsReadOnly();


        protected Section()
        {
            _students = [];
        }

        public Section(string? name) : this() { }        

        public void AddStudent(Person student)
        {
            if (_students == null) _students = new();
            _students.Add(student);
        }

        public void RemoveStudent(Person student) => _students!.Remove(student);
    }
    
}
