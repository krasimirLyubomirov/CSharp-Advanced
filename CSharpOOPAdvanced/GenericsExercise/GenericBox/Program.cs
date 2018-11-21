using System;

public class Program
{
    public static void Main()
    {
        Box<int> boxOfInt = new Box<int>(123123);
        Box<string> boxOfString = new Box<string>("life in a box");

        Console.WriteLine(boxOfInt);
        Console.WriteLine(boxOfString);
    }
}

