using System;

public class Program
{
    public static void Main()
    {
        Animal cat = new Cat("Pesho", "whiskas");
        Animal dog = new Dog("Gosho", "meat");

        Console.WriteLine(cat.ExplainSelf());
        Console.WriteLine(dog.ExplainSelf());
    }
}
