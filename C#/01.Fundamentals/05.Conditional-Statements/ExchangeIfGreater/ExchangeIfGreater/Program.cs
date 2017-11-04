using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeIfGreater
{
    public class Program
    {
        public static void Main()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if(firstNumber > secondNumber)
            {
                Console.WriteLine("{0} {1}",secondNumber, firstNumber);
            }
            else
            {
                Console.WriteLine("{0} {1}", firstNumber, secondNumber);
            }

        }
    }
}
