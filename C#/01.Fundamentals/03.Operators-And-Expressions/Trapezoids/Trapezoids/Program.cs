using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trapezoids
{
    public class Program
    {
        public static void Main()
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = ((sideA + sideB) * height) / 2;

            Console.WriteLine("{0:F7}", area);
        }
    }
}
