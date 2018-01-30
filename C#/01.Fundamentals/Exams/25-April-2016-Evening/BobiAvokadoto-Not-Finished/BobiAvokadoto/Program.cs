using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BobiAvokadoto
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int combosCount = int.Parse(Console.ReadLine());
            int[] combos = new int[combosCount];

            for (int i = 0; i < combosCount; i++)
            {
                combos[i] = int.Parse(Console.ReadLine());
            }

            string numberBitwise = Convert.ToString(number, 2).PadLeft(16, '0');
            var len = combos.Length;
            var bitLen = numberBitwise.Length - 1;
            var isOverlap = false;

            for (int k = 0; k < len; k++)
            {
                var comboBitwise = Convert.ToString(combos[k], 2).PadLeft(16, '0');

                for (int i = bitLen; i > 0; i--)
                {
                    var numBit = int.Parse(numberBitwise[i].ToString());
                    Console.WriteLine(numBit);
                    var comboBit = int.Parse(comboBitwise[i].ToString());
                    Console.WriteLine(comboBit);

                    if (numBit == comboBit)
                    {
                        Console.WriteLine("{0} {1}",combos[k], isOverlap);
                        isOverlap = true;
                        break;
                    }
                }
                if(!isOverlap)
                {
                    Console.WriteLine(combos[k]);
                }
            }
            



            //int a = 5;
            //int b = 6;
            //int v = 5 & 6;
            //Console.WriteLine("{0} {1} {2}", a.ToString(), b.ToString(), v.ToString());
            //Console.WriteLine(Convert.ToString(a, 2).PadLeft(16,'0'));
            //Console.WriteLine(Convert.ToString(b, 2).PadLeft(16, '0'));
            //Console.WriteLine(Convert.ToString(v, 2).PadLeft(16, '0'));

        }
    }
}
