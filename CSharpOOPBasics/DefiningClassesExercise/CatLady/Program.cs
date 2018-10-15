using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Cat> cats = new List<Cat>();

        string commands;
        while ((commands = Console.ReadLine()) != "End")
        {
            string[] tokens = commands.Split();
            string breed = tokens[0];
            string name = tokens[1];

            switch (breed)
            {
                case "Siamese":
                    int earSize = int.Parse(tokens[2]);
                    cats.Add(new Siamese(name, earSize));
                    break;
                case "Cymric":
                    double furLength = double.Parse(tokens[2]);
                    cats.Add(new Cymric(name, furLength));
                    break;
                case "StreetExtraordinaire":
                    int decibelsOfMeows = int.Parse(tokens[2]);
                    cats.Add(new StreetExtraordinaire(name, decibelsOfMeows));
                    break;
            }
        }

        string catName = Console.ReadLine();

        Cat cat = cats.Single(c => c.Name == catName);
        Console.WriteLine(cat);
    }
}

