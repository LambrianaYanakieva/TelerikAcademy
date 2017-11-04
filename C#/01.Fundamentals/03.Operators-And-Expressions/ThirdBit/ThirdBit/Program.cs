using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdBit
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            //Variant 1
            Console.WriteLine((number >> 3) & 1);

            //Variant 2: with mask
            int mask = 1 << 3;
            Console.WriteLine((number & mask) >> 3);
        }
    }
}
