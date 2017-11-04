using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOrEven
{
    public class Program
    {
        public static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            //Variant 1:
            if (input % 2 == 0)
            {
                Console.WriteLine("even {0}", input);
            }
            else
            {
                Console.WriteLine("odd {0}", input);
            }

            //Variant 2:
            if((input & 1) == 0)
            {
                Console.WriteLine("even {0}", input);
            }
            else
            {
                Console.WriteLine("odd {0}", input);
            }
        }
    }
}
