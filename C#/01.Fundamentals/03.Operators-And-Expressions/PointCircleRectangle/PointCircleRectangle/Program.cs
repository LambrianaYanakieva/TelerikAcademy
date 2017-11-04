using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointCircleRectangle
{
    public class Program
    {
        public static void Main()
        {
            double pointX = double.Parse(Console.ReadLine());
            double pointY = double.Parse(Console.ReadLine());
            double circleX = 1;
            double circleY = 1;
            double radius = 1.5;
            double rectWidth = 6;
            double rectHeight = 2;
            double rectTopY = 1;
            double rectLeftX = -1;

            //finding coordinates of the Right and Bottom sides of the rectangle
            double rectRightX = rectLeftX + rectWidth;
            double rectBottomY = rectTopY - rectHeight;
           
            //distance between circle and point
            double distCircle = Math.Sqrt(Math.Pow(pointX, 2) + Math.Pow(pointY, 2));

            //finding distance from PointX to CircleX and from PointY to CircleY
            double distOfPXtoCX = Math.Pow((pointX - circleX), 2);
            double distOfPYtoCY = Math.Pow((pointY - circleY), 2);

            //check if point is inside the circle
            bool isInCircle = (distOfPXtoCX + distOfPYtoCY <= radius * radius);

            //check if point is inside the rectangle
            bool checkX = (pointX >= rectLeftX) && (pointX <= rectRightX);
            bool checkY = (pointY <= rectTopY) && (pointY >= rectBottomY);
            bool isInRect = (checkX && checkY);

            Console.WriteLine((isInCircle ? "inside circle" : "outside circle") + " " + 
                (isInRect ? "inside rectangle" : "outside rectangle"));
        }
    }
}
