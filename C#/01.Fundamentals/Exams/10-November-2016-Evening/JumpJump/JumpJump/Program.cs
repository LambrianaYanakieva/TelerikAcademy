using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpJump
{
    public class Program
    {
        public static void Main()
        {
            string instructions = Console.ReadLine();

            for (int i = 0; i < instructions.Length;)
            {
                var value = instructions[i];
                
                if(value >= '0' && value <= '9')
                {
                    int number = (int)value - '0';
                    if(number == 0)
                    {
                        Console.WriteLine("Too drunk to go on after {0}!",i);
                        break;
                    }

                    if((number & 1) == 0)
                    {
                        i += number;
                        if(i >= instructions.Length)
                        {
                            Console.WriteLine("Fell off the dancefloor at {0}!",i);
                            break;
                        }
                    }
                    else
                    {
                        i -= number;
                        if (i < 0)
                        {
                            Console.WriteLine("Fell off the dancefloor at {0}!", i);
                            break;
                        }
                    }
                }
                else if(value == '^')
                {
                    Console.WriteLine("Jump, Jump, DJ Tomekk kommt at {0}!", i);
                    break;
                }

            }


        }
    }
}
