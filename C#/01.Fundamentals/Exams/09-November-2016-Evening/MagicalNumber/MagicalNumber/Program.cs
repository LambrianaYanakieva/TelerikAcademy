using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalNumber
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            float firstNumber = number / 100;
            float secondNumber = number / 10 % 10;
            float thirdNumber = number % 10;

            if(((int)secondNumber & 1) == 0)
            {
                float result = (firstNumber + secondNumber) * thirdNumber;
                Console.WriteLine("{0:F2}",result);
            }
            else
            {
                float result = (firstNumber * secondNumber) / thirdNumber;
                Console.WriteLine("{0:F2}",result);
            }
        }
    }
}
