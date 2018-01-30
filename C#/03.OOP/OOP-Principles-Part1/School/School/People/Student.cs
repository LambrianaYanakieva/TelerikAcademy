using System;

namespace School
{
    public class Student : Person
    {
        public Student(string firstName, string lastName)
            :base(firstName,lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ClassNumber = int.Parse(Guid.NewGuid().ToString("N"));
        }

        public override string FirstName { get; set; }

        public override string LastName { get; set; }

        public int ClassNumber { get; set; }

        
    }
}
