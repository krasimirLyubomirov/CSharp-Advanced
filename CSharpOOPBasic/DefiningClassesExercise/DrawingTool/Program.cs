using System;

class Program
{
    static void Main(string[] args)
    {
        string type = Console.ReadLine();

        switch (type)
        {
            case "Square":
                int firstWidth = int.Parse(Console.ReadLine());
                Square square = new Square(firstWidth);
                DrawingTools drawingTool = new DrawingTools(square);
                drawingTool.Figure.Draw();
                break;
            case "Rectangle":
                int secondWidth = int.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                Rectangle rectangle = new Rectangle(secondWidth, height);
                DrawingTools drawingTool2 = new DrawingTools(rectangle);
                drawingTool2.Figure.Draw();
                break;
        }
    }
}

