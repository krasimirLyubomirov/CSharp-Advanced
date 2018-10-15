using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] personInformation = Console.ReadLine().Split();
        List<Person> familyTree = new List<Person>();

        if (personInformation.Length == 1)
        {
            familyTree.Add(new Person(personInformation[0]));
        }
        else if (personInformation.Length == 2)
        {
            familyTree.Add(new Person(personInformation[0], personInformation[1]));
        }

        string commands;
        while ((commands = Console.ReadLine()) != "End")
        {
            string[] tokens = commands.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens.Length == 2)
            {
                if (familyTree.Any(p => p.BirthDate == tokens[0]) == false)
                {
                    familyTree.Add(new Person(tokens[0]));
                }

                Person parent = familyTree.First(p => p.BirthDate == tokens[0]);

                if (familyTree.Any(p => p.BirthDate == tokens[1]) == false)
                {
                    familyTree.Add(new Person(tokens[1]));
                }

                Person child = familyTree.First(p => p.BirthDate == tokens[1]);

                parent.AddChild(child);
                child.AddParent(parent);
            }
            else if (tokens.Length == 3)
            {
                if (commands.Contains("-"))
                {
                    if (Char.IsDigit(tokens[0][0]))
                    {
                        if (familyTree.Any(p => p.BirthDate == tokens[0]) == false)
                        {
                            familyTree.Add(new Person(tokens[0]));
                        }

                        Person parent = familyTree.First(p => p.BirthDate == tokens[0]);

                        if (familyTree.Any(p => p.FirstName == tokens[1] && p.LastName == tokens[2]) == false)
                        {
                            familyTree.Add(new Person(tokens[1], tokens[2]));
                        }

                        Person child = familyTree.First(p => p.FirstName == tokens[1] && p.LastName == tokens[2]);

                        parent.AddChild(child);
                        child.AddParent(parent);
                    }
                    else if (Char.IsDigit(tokens[2][0]))
                    {
                        if (familyTree.Any(p => p.BirthDate == tokens[2]) == false)
                        {
                            familyTree.Add(new Person(tokens[2]));
                        }

                        Person child = familyTree.First(p => p.BirthDate == tokens[2]);

                        if (familyTree.Any(p => p.FirstName == tokens[0] && p.LastName == tokens[1]) == false)
                        {
                            familyTree.Add(new Person(tokens[0], tokens[1]));
                        }

                        Person parent = familyTree.First(p => p.FirstName == tokens[0] && p.LastName == tokens[1]);

                        parent.AddChild(child);
                        child.AddParent(parent);
                    }
                }
                else
                {
                    Person[] persons = familyTree.Where(p => (p.FirstName == tokens[0] && p.LastName == tokens[1]) || p.BirthDate == tokens[2]).ToArray();

                    List<Person> childrens = new List<Person>();
                    List<Person> parents = new List<Person>();

                    foreach (var person in persons)
                    {
                        childrens.AddRange(person.Childrens);
                        parents.AddRange(person.Parents);
                    }

                    foreach (var person in persons)
                    {
                        person.FirstName = tokens[0];
                        person.LastName = tokens[1];
                        person.BirthDate = tokens[2];
                        person.Childrens = childrens;
                        person.Parents = parents;
                    }
                }
            }
            else if (tokens.Length == 4)
            {
                if (familyTree.Any(p => p.FirstName == tokens[0] && p.LastName == tokens[1]) == false)
                {
                    familyTree.Add(new Person(tokens[0], tokens[1]));
                }

                Person parent = familyTree.First(p => p.FirstName == tokens[0] && p.LastName == tokens[1]);

                if (familyTree.Any(p => p.FirstName == tokens[2] && p.LastName == tokens[3]) == false)
                {
                    familyTree.Add(new Person(tokens[2], tokens[3]));
                }

                Person child = familyTree.First(p => p.FirstName == tokens[2] && p.LastName == tokens[3]);

                parent.AddChild(child);
                child.AddParent(parent);
            }
        }

        Person target = null;
        if (personInformation.Length == 1)
        {
            target = familyTree.First(p => p.BirthDate == personInformation[0]);
        }
        else if (personInformation.Length == 2)
        {
            target = familyTree.First(p => p.FirstName == personInformation[0] && p.LastName == personInformation[1]);
        }

        Console.WriteLine(target);
    }
}

