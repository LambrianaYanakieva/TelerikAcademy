using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyBit
{
    public class Program
    {
        public static void Main()
        {
            ulong number = ulong.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            ulong value = ulong.Parse(Console.ReadLine());

            int mask1 = 1 << position;
            int mask2 = ~(1 << position);

            //Console.WriteLine("Mask1: {0}", Convert.ToString(mask1,2));
            //Console.WriteLine("Mask2: {0}", Convert.ToString(mask2,2));

            if (number == 0)
            {
                if(value == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(mask1);
                }
            }
            else
            {
                int numAndMask = (int)number & mask1;
                ulong bitValue = (ulong)numAndMask >> position;

                //Console.WriteLine("Bit Value: {0}", bitValue);

                ulong result = 0;

                if (bitValue == 1 && bitValue != value)
                {
                    result = number & (ulong)mask2;
                    Console.WriteLine(result);
                }
                else if(bitValue == 0 && bitValue != value)
                {
                    result = (number | (ulong)mask1);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine(number);
                }
            }                  
        }
    }
}
