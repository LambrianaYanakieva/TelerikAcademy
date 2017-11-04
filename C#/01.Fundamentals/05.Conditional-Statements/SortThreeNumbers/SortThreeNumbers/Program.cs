using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());//3
            int secondNum = int.Parse(Console.ReadLine());//2
            int thirdNum = int.Parse(Console.ReadLine());//1

            bool isFirstGreater = firstNum > secondNum ? true : false;
            if (isFirstGreater)
            {
                isFirstGreater = firstNum > thirdNum ? true : false;
                if (isFirstGreater)
                {
                    if (secondNum > thirdNum)
                    {
                        Console.WriteLine("{0} {1} {2}", firstNum, secondNum, thirdNum);
                    }
                    else
                    {
                        Console.WriteLine("{0} {1} {2}", firstNum, thirdNum, secondNum);
                    }
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", thirdNum, firstNum, secondNum);
                }
            }
            else
            {
                bool isSecondGreatest = secondNum > thirdNum ? true : false;
                if (isSecondGreatest)
                {
                    Console.WriteLine("{0} {1} {2}", secondNum, thirdNum, firstNum);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", thirdNum, secondNum, firstNum);
                }
            }
        }
    }
}
