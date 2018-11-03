using System;

public class Rectangle : Shape
{
    public Rectangle(double sideA, double sideB)
    {
        this.SideA = sideA;
        this.SideB = sideB;
    }

    private double sideA;
    private double sideB;

    public double SideA
    {
        get { return sideA; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.SideA), "Side A must be non-zero and positive");
            }

            this.sideA = value;
        }
    }

    public double SideB
    {
        get { return sideB; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.SideB), "Side B must be non-zero and positive");
            }

            this.sideB = value;
        }
    }

    public override double CalculateArea()
    {
        double area = this.SideA * this.SideB;
        return area;
    }

    public override double CalculatePerimeter()
    {
        double perimeter = (this.SideA + this.SideB) * 2;
        return perimeter;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}

