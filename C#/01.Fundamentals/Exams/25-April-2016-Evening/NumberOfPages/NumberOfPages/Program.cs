using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfPages
{
    public class Program
    {
        public static void Main()
        {
            long digits = int.Parse(Console.ReadLine());
            long numberOfPages = 0;

            for (long i = 1; i <= digits;)
            {
                numberOfPages++;

                if (numberOfPages <= 9)
                {  
                    i++;  
                }
                else if( numberOfPages >= 10 && numberOfPages <= 99)
                {
                    i += 2;              
                }
                else if(numberOfPages >= 100 && numberOfPages <= 999)
                {
                    i += 3;                
                }
                else if(numberOfPages >= 1000 && numberOfPages <= 9999)
                {
                    i += 4;             
                }
                else if(numberOfPages >= 10000 && numberOfPages <= 99999)
                {
                    i += 5;             
                }
                else if(numberOfPages >= 100000 && numberOfPages <= 999999)
                {
                    i += 6;              
                }
                else if(numberOfPages >= 1000000 && numberOfPages <= 9999999)
                {
                    i += 7;                  
                }                
            }
            Console.WriteLine(numberOfPages);
        }
    }
}
