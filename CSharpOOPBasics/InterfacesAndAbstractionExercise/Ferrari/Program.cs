using System;

public class Program
{
    public static void Main()
    {
        string driverName = Console.ReadLine();
        IFerrari driver = new Ferrari(driverName);
        Console.WriteLine(driver);
    }
}

