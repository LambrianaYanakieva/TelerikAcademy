using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInACircle
{
    public class Program
    {
        public static void Main()
        {
            double circleX = 0;
            double circleY = 0;
            double radius = 2;
            double pointX = double.Parse(Console.ReadLine());
            double pointY = double.Parse(Console.ReadLine());
            double distance = Math.Sqrt(Math.Pow(pointX,2) + Math.Pow(pointY,2));
            double distOfPointX = Math.Pow((pointX - circleX), 2);
            double distOfPointY = Math.Pow((pointY - circleY), 2);
            bool isInCircle = (distOfPointX + distOfPointY <= radius * radius);

            if (isInCircle)
            {
                Console.WriteLine("yes {0:F2}", distance);
            }
            else
            {
                Console.WriteLine("no {0:F2}", distance);
            }
        }
    }
}
