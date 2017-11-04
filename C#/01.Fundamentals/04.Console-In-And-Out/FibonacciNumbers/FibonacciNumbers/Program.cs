using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int numberA = 0;
            int numberB = 1;
            int numberC = 0;

           if(n == 1)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.Write(0 + ", ");
                Console.Write(1);

                while(n > 2)
                {
                    numberC = numberA + numberB;
                    numberA = numberB;
                    numberB = numberC;
                    Console.Write(", {0}", numberB);
                    n--;
                }
            }
        }
    }
}
