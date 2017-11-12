using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixingNumber
{
    public class Program
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            int[] array = new int[lines];
            int[] mixed = new int[lines - 1];
            int[] substracted = new int[lines - 1];

            for (int i = 0; i < lines; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 1; i <= lines -1; i++)
            {
                mixed[i - 1] = (array[i - 1] % 10) * (array[i] / 10);
                substracted[i - 1] = Math.Abs(array[i - 1] - array[i]);
            }

            Console.WriteLine(string.Join(" ", mixed));
            Console.WriteLine(string.Join(" ", substracted));

        }
    }
}
