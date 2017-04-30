using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgasCitizens
{
    public class StartUp
    {
        public static void Main()
        {
            var citizen = CitizenGenerator.Create(21);

            Console.WriteLine("My name is {0}. I am {2} years old {3}", citizen.Title, citizen.Age, citizen.Type);
        }
    }
}
