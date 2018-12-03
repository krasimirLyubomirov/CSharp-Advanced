using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int numberOfRectangles = int.Parse(input[0]);
        int intersectionChecks = int.Parse(input[1]);

        List<Rectangle> rectangles = new List<Rectangle>();

        for (int rectangle = 0; rectangle < numberOfRectangles; rectangle++)
        {
            string[] rectangleInput = Console.ReadLine().Split();
            string id = rectangleInput[0];
            double width = double.Parse(rectangleInput[1]);
            double height = double.Parse(rectangleInput[2]);
            double x = double.Parse(rectangleInput[3]);
            double y = double.Parse(rectangleInput[4]);

            Rectangle rectangleInfo = new Rectangle(id, width, height, x, y);
            rectangles.Add(rectangleInfo);
        }

        for (int check = 0; check < intersectionChecks; check++)
        {
            string[] checks = Console.ReadLine().Split();
            string firstId = checks[0];
            string secondId = checks[1];

            Rectangle firstRectangle = rectangles.First(r => r.Id == firstId);
            Rectangle secondRectangle = rectangles.First(r => r.Id == secondId);

            if (firstRectangle.Intersects(secondRectangle))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}

