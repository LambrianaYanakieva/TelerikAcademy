using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interval
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = n + 1; i < m; i++)
            {
                if(i % 5 == 0)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);


        }
    }
}
