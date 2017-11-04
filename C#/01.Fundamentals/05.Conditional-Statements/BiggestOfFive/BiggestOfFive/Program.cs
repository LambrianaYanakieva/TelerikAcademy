using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggestOfFive
{
    public class Program
    {
        public static void Main()
        {
            float first = float.Parse(Console.ReadLine());
            float second = float.Parse(Console.ReadLine());
            float third = float.Parse(Console.ReadLine());
            float fourth = float.Parse(Console.ReadLine());
            float fifth = float.Parse(Console.ReadLine());

            float firstBigNum = first > second ? first : second;
            float secondBigNum = firstBigNum > third ? first : third;
            float thirdBigNum = secondBigNum > fourth ? secondBigNum : fourth;
            float fourthBigNum = thirdBigNum > fifth ? thirdBigNum : fifth;
            float biggestNum = fourthBigNum > firstBigNum ? fourthBigNum : firstBigNum;

            Console.WriteLine(biggestNum);
        }
    }
}
