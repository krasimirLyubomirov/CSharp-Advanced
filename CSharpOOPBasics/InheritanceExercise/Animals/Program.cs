﻿using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();

        string animalType;
        while ((animalType = Console.ReadLine()) != "Beast!") 
        {
            try
            {
                ReadAndCreateAnimal(animals, animalType);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static void ReadAndCreateAnimal(List<Animal> animals, string animalType)
    {
        string[] tokens = Console.ReadLine().Split();
        string name = tokens[0];
        int age = int.Parse(tokens[1]);
        string gender = null;

        if (tokens.Length == 3)
        {
            gender = tokens[2];
        }

        switch (animalType)
        {
            case "Cat":
                Cat cat = new Cat(name, age, gender);
                animals.Add(cat);
                break;
            case "Dog":
                Dog dog = new Dog(name, age, gender);
                animals.Add(dog);
                break;
            case "Frog":
                Frog frog = new Frog(name, age, gender);
                animals.Add(frog);
                break;
            case "Tomcat":
                Tomcat tomcat = new Tomcat(name, age);
                animals.Add(tomcat);
                break;
            case "Kitten":
                Kitten kitten = new Kitten(name, age);
                animals.Add(kitten);
                break;
            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}

