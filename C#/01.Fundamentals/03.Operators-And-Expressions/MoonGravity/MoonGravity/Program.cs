using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonGravity
{
    public class Program
    {
        public static void Main()
        {
            float weightOnEarth = float.Parse(Console.ReadLine());
            float weightOnMoon = (weightOnEarth * 17 / 100);
            Console.WriteLine("{0:F3}",weightOnMoon);
        }
    }
}
