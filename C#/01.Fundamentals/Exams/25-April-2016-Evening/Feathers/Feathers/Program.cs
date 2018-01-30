using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feathers
{
    public class Program
    {
        public static void Main()
        {
            const double magicNumberEven = 123123123123;
            const double magicNumberOdd = 317;

            double birds = double.Parse(Console.ReadLine());
            double feathers = double.Parse(Console.ReadLine());

            double average = feathers / birds;
            double result = average;

            if(((int)birds & 1) == 0)
            {
                result = average * magicNumberEven;
            }
            else
            {
                result = average / magicNumberOdd;
            }

            Console.WriteLine("{0:F4}", result);
        }
    }
}
