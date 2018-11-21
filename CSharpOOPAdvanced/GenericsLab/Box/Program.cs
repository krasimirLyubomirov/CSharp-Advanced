using System;

public class Program
{
    public static void Main()
    {
        Box<int> box = new Box<int>();

        box.Add(2);
        box.Add(3);
        box.Add(4);
        box.Add(5);

        int element = box.Remove();

        Console.WriteLine(element);
        Console.WriteLine(box.Count);
    }
}

