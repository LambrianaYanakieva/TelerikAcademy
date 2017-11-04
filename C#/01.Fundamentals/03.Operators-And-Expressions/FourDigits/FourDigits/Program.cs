using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourDigits
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            int fourthDigit = number % 10;
            int thirdDigit = (number / 10) % 10;
            int secondDigit = (number / 100) % 10;
            int firstDigit = (number / 100) / 10;

            int sum = firstDigit + secondDigit + thirdDigit + fourthDigit;
            string reversed = fourthDigit.ToString() + thirdDigit + secondDigit + firstDigit;
            string lastDigitGoesFirst = fourthDigit.ToString() + firstDigit + secondDigit + thirdDigit;
            string swappedMiddleDigits = firstDigit.ToString() + thirdDigit + secondDigit + fourthDigit;

            Console.WriteLine(sum);
            Console.WriteLine(reversed);
            Console.WriteLine(lastDigitGoesFirst);
            Console.WriteLine(swappedMiddleDigits);
        }
    }
}
