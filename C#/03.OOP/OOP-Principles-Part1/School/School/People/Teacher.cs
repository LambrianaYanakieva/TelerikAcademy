using System.Collections.Generic;

namespace School.People
{
    public class Teacher : Person
    {
        public Teacher(string firstName, string lastName)
            :base(firstName, lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Disciplines = new List<Discipline>();
        }

        public override string FirstName { get; set; }

        public override string LastName { get; set; }

        public IList<Discipline> Disciplines { get; set; }
    }
}
