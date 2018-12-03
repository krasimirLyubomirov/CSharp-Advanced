public abstract class Shape
{
    public abstract double CalculateArea();

    public abstract double CalculatePerimeter();

    public virtual string Draw()
    {
        string result = "Drawing ";
        return result;
    }
}

