using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitAsWord
{
    public class Program
    {
        public static void Main()
        {
            string digit = Console.ReadLine();

            switch (digit)
            {
                case "0":
                    Console.WriteLine("zero");
                    return;
                case "1":
                    Console.WriteLine("one");
                    return;
                case "2":
                    Console.WriteLine("two");
                    return;
                case "3":
                    Console.WriteLine("three");
                    return;
                case "4":
                    Console.WriteLine("four");
                    return;
                case "5":
                    Console.WriteLine("five");
                    return;
                case "6":
                    Console.WriteLine("six");
                    return;
                case "7":
                    Console.WriteLine("seven");
                    return;
                case "8":
                    Console.WriteLine("eight");
                    return;
                case "9":
                    Console.WriteLine("nine");
                    return;
                default:
                    Console.WriteLine("not a digit");
                    return;

            }

        }
    }
}
