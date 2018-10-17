namespace PointInRectangle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace PointInRectangle
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int> rectangleCoordinates = Console.ReadLine().Split().Select(int.Parse).ToList();
                int topX = rectangleCoordinates[0];
                int topY = rectangleCoordinates[1];
                int bottomX = rectangleCoordinates[2];
                int bottomY = rectangleCoordinates[3];

                Rectangle rectangle = new Rectangle(topX, topY, bottomX, bottomY);
                int pointsCount = int.Parse(Console.ReadLine());

                for (int pointsCounter = 0; pointsCounter < pointsCount; pointsCounter++)
                {
                    List<int> pointsCoordinates = Console.ReadLine().Split().Select(int.Parse).ToList();
                    int x = pointsCoordinates[0];
                    int y = pointsCoordinates[1];

                    Point point = new Point(x, y);
                    bool containsPoint = rectangle.Contains(point);

                    Console.WriteLine(containsPoint);
                }
            }
        }
    }
}
