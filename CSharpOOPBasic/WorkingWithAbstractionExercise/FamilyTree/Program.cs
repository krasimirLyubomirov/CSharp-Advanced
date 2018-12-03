namespace FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string[] manInfo = Console.ReadLine().Split();
            List<Person> familyTree = new List<Person>();

            if (manInfo.Length == 1)
            {
                familyTree.Add(new Person(manInfo[0]));
            }
            else if (manInfo.Length == 2)
            {
                familyTree.Add(new Person(manInfo[0], manInfo[1]));
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2)
                {
                    if (!familyTree.Any(p => p.BirthDate == tokens[0]))
                    {
                        familyTree.Add(new Person(tokens[0]));
                    }

                    Person parent = familyTree.First(p => p.BirthDate == tokens[0]);

                    if (!familyTree.Any(p => p.BirthDate == tokens[1]))
                    {
                        familyTree.Add(new Person(tokens[1]));
                    }

                    Person child = familyTree.First(p => p.BirthDate == tokens[1]);

                    parent.AddChild(child);
                    child.AddParent(parent);
                }
                else if (tokens.Length == 3)
                {
                    if (command.Contains("-"))
                    {
                        if (Char.IsDigit(tokens[0][0]))
                        {
                            if (!familyTree.Any(p => p.BirthDate == tokens[0]))
                            {
                                familyTree.Add(new Person(tokens[0]));
                            }

                            Person parent = familyTree.First(p => p.BirthDate == tokens[0]);

                            if (!familyTree.Any(p => p.FirstName == tokens[1] && p.LastName == tokens[2]))
                            {
                                familyTree.Add(new Person(tokens[1], tokens[2]));
                            }

                            Person child = familyTree.First(p => p.FirstName == tokens[1] && p.LastName == tokens[2]);

                            parent.AddChild(child);
                            child.AddParent(parent);
                        }
                        else if (Char.IsDigit(tokens[2][0]))
                        {
                            if (!familyTree.Any(p => p.BirthDate == tokens[2]))
                            {
                                familyTree.Add(new Person(tokens[2]));
                            }

                            Person child = familyTree.First(p => p.BirthDate == tokens[2]);

                            if (!familyTree.Any(p => p.FirstName == tokens[0] && p.LastName == tokens[1]))
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
                        List<Person> persons = familyTree.Where(p => (p.FirstName == tokens[0] && p.LastName == tokens[1]) || p.BirthDate == tokens[2]).ToList();

                        List<Person> children = new List<Person>();
                        List<Person> parents = new List<Person>();

                        foreach (var person in persons)
                        {
                            children.AddRange(person.Children);
                            parents.AddRange(person.Parents);
                        }

                        foreach (var person in persons)
                        {
                            person.FirstName = tokens[0];
                            person.LastName = tokens[1];
                            person.BirthDate = tokens[2];
                            person.Children = children;
                            person.Parents = parents;
                        }
                    }
                }
                else if (tokens.Length == 4)
                {
                    if (!familyTree.Any(p => p.FirstName == tokens[0] && p.LastName == tokens[1]))
                    {
                        familyTree.Add(new Person(tokens[0], tokens[1]));
                    }

                    Person parent = familyTree.First(p => p.FirstName == tokens[0] && p.LastName == tokens[1]);

                    if (!familyTree.Any(p => p.FirstName == tokens[2] && p.LastName == tokens[3]))
                    {
                        familyTree.Add(new Person(tokens[2], tokens[3]));
                    }

                    Person child = familyTree.First(p => p.FirstName == tokens[2] && p.LastName == tokens[3]);

                    parent.AddChild(child);
                    child.AddParent(parent);
                }
            }

            Person target = null;
            if (manInfo.Length == 1)
            {
                target = familyTree.First(p => p.BirthDate == manInfo[0]);
            }
            else if (manInfo.Length == 2)
            {
                target = familyTree.First(p => p.FirstName == manInfo[0] && p.LastName == manInfo[1]);
            }

            Console.WriteLine(target);
        }
    }
}