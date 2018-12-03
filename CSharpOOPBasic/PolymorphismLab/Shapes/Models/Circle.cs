using System;

public class Circle : Shape
{
    public Circle(double radius)
    {
        this.Radius = radius;
    }

    private double radius;

    public double Radius
    {
        get { return this.radius; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.radius), "Circle cannot have a zero or negative radius!");
            }

            this.radius = value;
        }
    }

    public override double CalculateArea()
    {
        double area = Math.PI * this.Radius * this.Radius;
        return area;
    }

    public override double CalculatePerimeter()
    {
        double perimeter = 2 * Math.PI * this.Radius;
        return perimeter;
    }

    public override string Draw()
    {
        return base.Draw() + "Circle";
    }
}
