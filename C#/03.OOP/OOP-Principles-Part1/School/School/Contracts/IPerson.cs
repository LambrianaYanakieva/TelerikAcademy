namespace School
{
    public abstract class Person
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public abstract string FirstName { get; set; }

        public abstract string LastName { get; set; }
    }
}
