using System;

public class Program
{
    public static void Main()
    {
        AddCollection addCollection = new AddCollection();
        AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        MyList myList = new MyList();

        string[] randomsStrings = Console.ReadLine().Split();

        foreach (var randomString in randomsStrings)
        {
            Console.Write($"{addCollection.Add(randomString)} ");
        }

        Console.WriteLine();

        foreach (var randomString in randomsStrings)
        {
            Console.Write($"{addRemoveCollection.Add(randomString)} ");
        }

        Console.WriteLine();

        foreach (var randomString in randomsStrings)
        {
            Console.Write($"{myList.Add(randomString)} ");
        }

        Console.WriteLine();

        int countOfRemoves = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfRemoves; i++)
        {
            Console.Write($"{addRemoveCollection.Remove()} ");
        }

        Console.WriteLine();

        for (int i = 0; i < countOfRemoves; i++)
        {
            Console.Write($"{myList.Remove()} ");
        }

        Console.WriteLine();
    }
}

