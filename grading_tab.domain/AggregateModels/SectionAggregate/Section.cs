using grading_tab.domain.AggregateModels.PersonAggregate;
using grading_tab.domain.SeedWork;
using System.Collections.ObjectModel;

namespace grading_tab.domain.AggregateModels.SectionAggregate
{
    public class Section : Entity, IAggregateRoot
    {
        public string? Name { get; private set; }

        private List<Student>? _students;
        public ReadOnlyCollection<Student> Students => _students!.AsReadOnly();


        protected Section()
        {
            _students = [];
        }

        public Section(string? name) : this() { }        

        public void AddStudent(Student student)
        {
            if (_students == null) _students = new();
            _students.Add(student);
        }

        public void RemoveStudent(Student student) => _students!.Remove(student);
    }

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
        
        protected Student(){}
    }
    
}
