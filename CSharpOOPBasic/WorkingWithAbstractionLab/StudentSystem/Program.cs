namespace StudentSystem
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            StudentSystem studentSystem = new StudentSystem();
            string commands;
            while ((commands = Console.ReadLine()) != "Exit")
            {
                studentSystem.ParseCommand(commands, Console.WriteLine);
            }
        }
    }
}