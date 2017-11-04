using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberComparer
{
    public class Program
    {
        public static void Main()
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            double greaterNumber = firstNumber > secondNumber ? firstNumber : secondNumber;
            Console.WriteLine(greaterNumber);


        }
    }
}
