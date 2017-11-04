using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggestOfThree
{
    public class Program
    {
        public static void Main()
        {
            float firstNum = float.Parse(Console.ReadLine());
            float secondNum = float.Parse(Console.ReadLine());
            float thisrdNum = float.Parse(Console.ReadLine());

            if (firstNum > secondNum)
            {
                Console.WriteLine(firstNum > thisrdNum ? firstNum : thisrdNum);

            }
            else
            {
                Console.WriteLine(secondNum > thisrdNum ? secondNum : thisrdNum);
            }
        }
    }
}
