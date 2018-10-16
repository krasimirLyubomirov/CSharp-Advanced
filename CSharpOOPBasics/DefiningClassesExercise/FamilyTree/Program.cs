namespace FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> familyTree = new List<Person>();
            List<string> ties = new List<string>();

            string nameOrBirthday = Console.ReadLine();

            string personInformation;
            while ((personInformation = Console.ReadLine()) != "End")
            {
                string[] tokens = personInformation.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 1)
                {
                    string[] parts = personInformation.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string name = $"{parts[0]} {parts[1]}";
                    string birthday = parts[2];
                    Person person = new Person(name, birthday);
                    familyTree.Add(person);
                }
                else
                {
                    ties.Add(personInformation);
                }
            }

            foreach (string tie in ties)
            {
                Person parent = new Person();
                Person child = new Person();

                string[] parts = tie.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                if (parts[0].Contains("/") && parts[1].Contains("/"))
                {
                    string parentBirthday = parts[0];
                    string childBirthday = parts[1];

                    parent = familyTree.First(p => p.Birthday == parentBirthday);
                    child = familyTree.First(p => p.Birthday == childBirthday);
                }
                else if (parts[0].Contains("/") || parts[1].Contains("/"))
                {
                    if (parts[0].Contains("/"))
                    {
                        string birthday = parts[0];
                        string name = parts[1];

                        parent = familyTree.First(p => p.Birthday == birthday);
                        child = familyTree.First(p => p.Name == name);
                    }
                    else
                    {
                        string birthday = parts[1];
                        string name = parts[0];

                        parent = familyTree.First(p => p.Name == name);
                        child = familyTree.First(p => p.Birthday == birthday);
                    }
                }
                else
                {
                    string parentName = parts[0];
                    string childName = parts[1];

                    parent = familyTree.First(p => p.Name == parentName);
                    child = familyTree.First(p => p.Name == childName);
                }

                if (parent.Children.Contains(child) == false)
                {
                    parent.Children.Add(child);
                }

                if (parent.Parents.Contains(parent) == false)
                {
                    child.Parents.Add(parent);
                }
            }
            
            Person targetPerson = new Person();

            if (nameOrBirthday.Contains("/"))
            {
                targetPerson = familyTree.First(p => p.Birthday == nameOrBirthday);
            }
            else
            {
                targetPerson = familyTree.First(p => p.Name == nameOrBirthday);
            }

            Console.WriteLine(targetPerson);
        }
    }
}