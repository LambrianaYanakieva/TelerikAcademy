using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinttheASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 255; i++)
            {
                Console.Write("{0}", (char)i);
            }
        }
    }
}
