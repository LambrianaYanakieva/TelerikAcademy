using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MythicalNumbers
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            
            float firstDigit = (number / 100) % 10;
            float secondDigit = (number / 10) % 10;
            float thirdDigit = number % 10;

            float result = 0;
            if(thirdDigit == 0)
            {
                result = firstDigit * secondDigit;
            }
            else if(thirdDigit >= 0 && thirdDigit <= 5)
            {
                result = (firstDigit * secondDigit) / thirdDigit;
            }
            else if(thirdDigit > 5)
            {
                result = (firstDigit + secondDigit) * thirdDigit;
            }

            Console.WriteLine("{0:F2}", result);

        }
    }
}
