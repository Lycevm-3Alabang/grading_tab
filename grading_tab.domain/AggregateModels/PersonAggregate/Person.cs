﻿using grading_tab.domain.SeedWork;

namespace grading_tab.domain.AggregateModels.PersonAggregate
{
    public class Person : Entity, IAggregateRoot
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Middlename { get; private set; }

        private Person() { }

        public Person(string? firstName, string? lastName, string? middlename)
        {
            FirstName = firstName;
            LastName = lastName;
            Middlename = middlename;
        }
    }

}
