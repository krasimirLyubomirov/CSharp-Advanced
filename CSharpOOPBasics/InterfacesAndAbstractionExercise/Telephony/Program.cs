using System;

public class Program
{
    public static void Main()
    {
        Smartphone smartphone = new Smartphone("IPhone");

        string[] phones = Console.ReadLine().Split();

        foreach (var phone in phones)
        {
            Console.WriteLine(smartphone.Call(phone));
        }

        string[] websites = Console.ReadLine().Split();

        foreach (var website in websites)
        {
            Console.WriteLine(smartphone.Browse(website));
        }
    }
}

