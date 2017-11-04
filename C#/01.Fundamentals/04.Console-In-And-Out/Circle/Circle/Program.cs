using System;

namespace Circle
{
    public class Program
    {
        public static void Main()
        {
            double radius = double.Parse(Console.ReadLine());

            double perimeter = 2 * Math.PI * radius;
            double area = Math.PI * Math.Pow(radius, 2);

            Console.WriteLine("{0:F2} {1:F2}", perimeter, area);

        }
    }
}
