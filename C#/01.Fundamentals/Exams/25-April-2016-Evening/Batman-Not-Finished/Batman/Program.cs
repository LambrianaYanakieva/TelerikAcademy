using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    public class Program
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char sign = char.Parse(Console.ReadLine());

            int wingRows = (size / 2) - 1;
            int bodyRows = (size - 2) - (size / 2);
            int tailRows = wingRows + 1;

            int tailLen = size - 2;
            var wingLen = new String(sign, size);
            var bodyLen = (3 * size) - ((wingRows + 2) * 2);

            var head = sign + " " + sign;
            var batHead = new String(' ', bodyRows) + head + new String(' ', bodyRows);

            var spaceBetweenWing = new String(' ', size);
            var spaceSideOfBody = (wingRows + 2);
            var tailWhiteSpace = ((size * 3) - tailLen) / 2;

            for (int i = 0; i < wingRows; i++)
            {
                var wing = new String(sign, size - i);
                var padLeft = new String(' ', i);
                var padCenter = new String(' ', size);
                Console.WriteLine(padLeft + wing + padCenter + wing);
            }

            var leftWing = new String(' ', wingRows) + new String(sign, size - wingRows);
            var rightWing = new String(sign, size - wingRows) + new String(' ', wingRows);
            Console.WriteLine(leftWing + batHead + rightWing);

            for (int i = 0; i < bodyRows; i++)
            {
                var padLeft = new String(' ', spaceSideOfBody);
                var padRight = new String(' ', spaceSideOfBody);
                var body = new String(sign, bodyLen);
                Console.WriteLine(padLeft + body + padRight);
            }

            var tailPadLeft = new String(' ', tailWhiteSpace);
            var tail = new String(sign, tailLen);
            Console.WriteLine(tailPadLeft + tail);

            for (int i = 0; i < tailRows-1; i++)
            {
                var tailLeftPad = new String(' ', tailWhiteSpace += 1);
                var tailBody = new String(sign, tailLen -= 2);
                Console.WriteLine(tailLeftPad + tail);
            }
            
        }
    }
}
