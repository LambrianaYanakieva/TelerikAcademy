using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthBit
{
    public class Program
    {
        public static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            int bit = int.Parse(Console.ReadLine());

            long mask = 1 << bit;
            long numberAndMask = number & mask;
            long result = numberAndMask >> bit;

            Console.WriteLine(result);
        }
    }
}
