using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitSwap
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int bitStartIndX = int.Parse(Console.ReadLine());
            int bitStartIndY = int.Parse(Console.ReadLine());
            int keyIndex = int.Parse(Console.ReadLine());
            int bitEndIndX = bitStartIndX + keyIndex - 1;
            int bitEndIndY = bitStartIndY + keyIndex - 1;
            int result = number;

            result = Exchange(number, bitStartIndX, bitEndIndX, bitStartIndY, bitEndIndY, result);
            result = Exchange(number, bitStartIndY, bitEndIndY, bitStartIndX, bitEndIndX, result);
            Console.WriteLine(result);
        }

        public static int Exchange(int number, int currentIndex, int endInd, int currentTargetInd,int endTargetInd, int result)
        {
            while (currentIndex <= endInd && currentTargetInd <= endTargetInd)
            {
                int bitValue = (number & (1 << currentIndex)) >> currentIndex;
                int exchangeWithZero = ~(1 << currentTargetInd) & result;
                int exchangeWithOne = (1 << currentTargetInd) | result;

                result = bitValue == 0 ? exchangeWithZero : exchangeWithOne;

                currentIndex++;
                currentTargetInd++;
            }
            return result;
        }
    }
}
