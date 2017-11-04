using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationSign
{
    public class Program
    {
        public static void Main()
        {
            float firstNumber = float.Parse(Console.ReadLine());
            float secondNumber = float.Parse(Console.ReadLine());
            float thirdNumber = float.Parse(Console.ReadLine());

            if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
            {
                Console.WriteLine(0);
            }
            else if (firstNumber > 0 && secondNumber > 0 && thirdNumber > 0)
            {
                Console.WriteLine("+");
            }
            else if (firstNumber < 0 && secondNumber < 0 && thirdNumber < 0)
            {
                Console.WriteLine("-");
            }
            else if((firstNumber < 0 && secondNumber > 0 && thirdNumber > 0) || 
                (firstNumber > 0 && secondNumber < 0 && thirdNumber > 0) || 
                (firstNumber > 0 && secondNumber > 0 && thirdNumber < 0))
            {
                Console.WriteLine("-");
            }
            else if((firstNumber < 0 && secondNumber < 0) || 
                (firstNumber < 0 && thirdNumber < 0) || 
                (thirdNumber < 0 && secondNumber < 0))
            {
                Console.WriteLine("+");
            }

                

        }
    }
}
