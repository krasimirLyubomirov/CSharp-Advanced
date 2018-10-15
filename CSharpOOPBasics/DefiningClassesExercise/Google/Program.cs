using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> peoples = new List<Person>();

        string personInformation;
        while ((personInformation = Console.ReadLine()) != "End")
        {
            string[] tokens = personInformation.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            string property = tokens[1];

            if (peoples.Any(p => p.Name == name) == false)
            {
                Person people = new Person(name);
                peoples.Add(people);
            }

            Person currentPerson = peoples.First(p => p.Name == name);
            switch (property)
            {
                case "company":
                    string companyName = tokens[2];
                    string department = tokens[3];
                    decimal salary = decimal.Parse(tokens[4]);
                    currentPerson.AssignCompany(companyName, department, salary);
                    break;
                case "pokemon":
                    string pokemonName = tokens[2];
                    string pokemonType = tokens[3];
                    currentPerson.AddPokemon(pokemonName, pokemonType);
                    break;
                case "parents":
                    string parentName = tokens[2];
                    Person parent = new Person(parentName, tokens[3]);
                    currentPerson.AddParent(parent);
                    break;
                case "children":
                    string childName = tokens[2];
                    Person children = new Person(childName, tokens[3]);
                    currentPerson.AddChild(children);
                    break;
                case "car":
                    string model = tokens[2];
                    int speed = int.Parse(tokens[3]);
                    currentPerson.AssignCar(model, speed);
                    break;
                default:
                    throw new Exception();
            }
        }

        personInformation = Console.ReadLine();
        Person person = peoples.First(p => p.Name == personInformation);
        Console.WriteLine(person);
    }
}

