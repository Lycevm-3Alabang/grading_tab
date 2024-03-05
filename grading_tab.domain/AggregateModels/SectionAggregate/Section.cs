using grading_tab.domain.SeedWork;
using System.Collections.ObjectModel;

namespace grading_tab.domain.AggregateModels.SectionAggregate
{
    public class Section : Entity, IAggregateRoot
    {
        public string? Name { get; private set; }

        private List<Student>? _students;
        public IEnumerable<Student> Students => _students!.AsReadOnly();


        protected Section()
        {
            _students = new();
        }

        public Section(string? name) : this() { }        

        public void AddStudent(Student student)
        {
            if (_students == null) _students = new();
            _students.Add(student);
        }

        public void RemoveStudent(Student student) => _students!.Remove(student);
    }
}
