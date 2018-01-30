using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busses
{
    public class Program
    {
        public static void Main()
        {
            int numberOfBusses = int.Parse(Console.ReadLine());
            int[] speeds = new int[numberOfBusses];
            int groupsCount = 1;
            int prevSpeed = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBusses - 1; i++)
            {
                var nextSpeed = int.Parse(Console.ReadLine());
                if (nextSpeed <= prevSpeed)
                {
                    prevSpeed = nextSpeed;
                    groupsCount++;
                }
            }

            Console.WriteLine(groupsCount);
        }
    }
}
