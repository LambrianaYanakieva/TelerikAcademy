using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayCard
{
    public class Program
    {
        public static void Main()
        {
            string card = Console.ReadLine();

            switch (card)
            {
                case "A":
                    Console.WriteLine("yes A");
                    return;
                case "K":
                    Console.WriteLine("yes K");
                    return;
                case "Q":
                    Console.WriteLine("yes Q");
                    return;
                case "J":
                    Console.WriteLine("yes J");
                    return;
                case "2":
                    Console.WriteLine("yes 2");
                    return;
                case "3":
                    Console.WriteLine("yes 3");
                    return;
                case "4":
                    Console.WriteLine("yes 4");
                    return;
                case "5":
                    Console.WriteLine("yes 5");
                    return;
                case "6":
                    Console.WriteLine("yes 6");
                    return;
                case "7":
                    Console.WriteLine("yes 7");
                    return;
                case "8":
                    Console.WriteLine("yes 8");
                    return;
                case "9":
                    Console.WriteLine("yes 9");
                    return;
                case "10":
                    Console.WriteLine("yes 10");
                    return;
                default:
                    Console.WriteLine("no {0}", card);
                    break;
            }
        }
    }
}
