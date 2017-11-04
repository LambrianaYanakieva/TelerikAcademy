using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExchangeSecondVariant
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int result = number;

            result = Exchange(number, 3, 24, result);
            result = Exchange(number, 4, 25, result);
            result = Exchange(number, 5, 26, result);
            result = Exchange(number, 24, 3, result);
            result = Exchange(number, 25, 4, result);
            result = Exchange(number, 26, 5, result);

            Console.WriteLine(result);
        }

        public static int Exchange(int number, int currentPos, int targetPos, int result)
        {
            int bitValue = (number & (1 << currentPos)) >> currentPos;
            int exchangeWithZero = ~(1 << targetPos) & result;
            int exchangeWithOne = (1 << targetPos) | result;

            result = bitValue == 0 ? exchangeWithZero : exchangeWithOne;
            return result;
        }
    }
}
