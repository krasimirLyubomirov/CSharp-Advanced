namespace Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> peoples = new Dictionary<string, Person>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string property = tokens[1];

                if (peoples.ContainsKey(name) == false)
                {
                    peoples[name] = new Person(name);
                }

                switch (property)
                {
                    case "company":
                        string companyName = tokens[2];
                        string department = tokens[3];
                        decimal salary = decimal.Parse(tokens[4]);
                        Company company = new Company(companyName, department, salary);
                        peoples[name].Company = company;
                        break;
                    case "pokemon":
                        string pokemonName = tokens[2];
                        string type = tokens[3];
                        Pokemon pokemon = new Pokemon(pokemonName, type);
                        peoples[name].Pokemons.Add(pokemon);
                        break;
                    case "parents":
                        string parentName = tokens[2];
                        string parentBirthday = tokens[3];
                        Parent parent = new Parent(parentName, parentBirthday);
                        peoples[name].Parents.Add(parent);
                        break;
                    case "children":
                        string childName = tokens[2];
                        string childBirthday = tokens[3];
                        Child child = new Child(childName, childBirthday);
                        peoples[name].Children.Add(child);
                        break;
                    case "car":
                        string model = tokens[2];
                        int speed = int.Parse(tokens[3]);
                        Car car = new Car(model, speed);
                        peoples[name].Car = car;
                        break;
                }
            }

            string searchedName = Console.ReadLine();
            Person person = peoples.Values.FirstOrDefault(p => p.Name == searchedName);
            Console.WriteLine(person);
        }
    }
}