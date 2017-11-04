using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExchange
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int result = number;

            //Console.WriteLine(Convert.ToString(number,2).PadLeft(32,'0'));

            result = ((number & (1 << 3)) >> 3) == 0 ? ~(1 << 24) & result : (1 << 24) | result;
            result = ((number & (1 << 4)) >> 4) == 0 ? ~(1 << 25) & result : (1 << 25) | result;
            result = ((number & (1 << 5)) >> 5) == 0 ? ~(1 << 26) & result : (1 << 26) | result;
            result = ((number & (1 << 24)) >> 24) == 0 ? ~(1 << 3) & result : (1 << 3) | result;
            result = ((number & (1 << 25)) >> 25) == 0 ? ~(1 << 4) & result : (1 << 4) | result;
            result = ((number & (1 << 26)) >> 26) == 0 ? ~(1 << 5) & result : (1 << 5) | result;

            //Console.WriteLine(Convert.ToString(result,2).PadLeft(32,'0'));
            Console.WriteLine(result);
        }
    }
}
