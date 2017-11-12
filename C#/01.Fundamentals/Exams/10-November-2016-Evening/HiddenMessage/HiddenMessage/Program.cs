using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenMessage
{
    public class Program
    {
        public static void Main()
        {
           
            string result = string.Empty;
            var input = Console.ReadLine();
           
            while (input != "end")
            {
                var index = int.Parse(input);
                int skip = int.Parse(Console.ReadLine());
                string line = Console.ReadLine();

                if (index < 0)
                {
                    index = line.Length + index;
                }

                for (int i = index; i < line.Length && i >= 0;)
                {
                    result += line[i];

                    i += skip;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(result);
        }
    }
}
