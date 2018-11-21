using System;

public class Program
{
    static void Main(string[] args)
    {
        Scale<string> scale = new Scale<string>("Gosho", "Pesho");
        Console.WriteLine(scale.GetHeavier());
    }
}

