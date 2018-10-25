using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Player player = new Player();
        player.Eat(Console.ReadLine().Split().Where(p => p != string.Empty).Select(p => FoodFactory.GetFood(p)));
        Console.WriteLine(player);
    }
}

