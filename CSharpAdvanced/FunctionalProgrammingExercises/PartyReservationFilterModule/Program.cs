using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invitations = Console.ReadLine().Split().ToList();
            List<string> results = new List<string>(invitations);
            List<string> filteredPerson = new List<string>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(';');
                if (commands[0] == "Print")
                {
                    break;
                }

                string command = commands[0];
                string filterType = commands[1];

                if (filterType == "Starts with")
                {
                    string startsWith = commands[2];
                    filteredPerson = invitations.Where(i => i.StartsWith(startsWith)).ToList();
                }
                else if (filterType == "Ends with")
                {
                    string endsWith = commands[2];
                    filteredPerson = invitations.Where(i => i.EndsWith(endsWith)).ToList();
                }
                else if (filterType == "Length")
                {
                    int length = int.Parse(commands[2]);
                    filteredPerson = invitations.Where(i => i.Length == length).ToList();
                }
                else if (filterType == "Contains")
                {
                    string contains = commands[2];
                    filteredPerson = invitations.Where(i => i.Contains(contains)).ToList();
                }

                if (command == "Add filter")
                {
                    results.RemoveAll(r => filteredPerson.Contains(r)); 
                }
                else if (command == "Remove filter")
                {
                    results.AddRange(filteredPerson);
                    results = results.Distinct().ToList();
                }
            }

            invitations.RemoveAll(i => !results.Contains(i));
            Console.WriteLine(String.Join(" ", invitations));
        }
    }
}
