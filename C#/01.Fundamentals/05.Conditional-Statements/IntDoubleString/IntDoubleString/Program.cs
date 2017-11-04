using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntDoubleString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var type = Console.ReadLine();
            var value = Console.ReadLine();

            switch (type)
            {
                case "integer":
                    int integer = int.Parse(value);
                    Console.WriteLine(integer + 1);
                    return;
                case "real":
                    double real = double.Parse(value);
                    real += 1;
                    Console.WriteLine("{0:F2}", real);
                    return;
                case "text":
                    Console.WriteLine(value + "*");
                    return;
            }
        }
    }
}
