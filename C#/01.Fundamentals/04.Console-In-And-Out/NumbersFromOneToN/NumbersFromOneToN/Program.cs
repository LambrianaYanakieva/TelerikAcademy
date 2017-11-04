using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersFromOneToN
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int start = 1;
           while(start <= n)
            {
                Console.WriteLine(start);
                start++;
            }

        }
    }
}
