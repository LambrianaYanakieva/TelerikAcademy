using School.People;
using System.Collections.Generic;

namespace School.Classes
{
    public class Class
    {
        public Class()
        {
            this.Teachers = new List<Teacher>();
        }
        public IList<Teacher> Teachers { get; set; }
    }
}
