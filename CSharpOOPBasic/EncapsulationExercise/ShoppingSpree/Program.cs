using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] personsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<Person> persons = new List<Person>();

            foreach (var personInput in personsInput)
            {
                string[] tokens = personInput.Split('=');
                string personName = tokens[0];
                decimal personMoney = decimal.Parse(tokens[1]);

                Person person = new Person(personName, personMoney);
                persons.Add(person);
            }

            List<Product> products = new List<Product>();

            foreach (var productInput in productsInput)
            {
                string[] tokens = productInput.Split('=');
                string productName = tokens[0];
                decimal productPrice = decimal.Parse(tokens[1]);

                Product product = new Product(productName, productPrice);
                products.Add(product);
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split();
                string personName = tokens[0];
                string productName = tokens[1];

                Person person = persons.First(p => p.Name == personName);
                Product product = products.First(p => p.Name == productName);

                string output = person.TryBuyProduct(product);
                Console.WriteLine(output);
            }

            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
        catch (ArgumentException argumentException)
        {
            Console.WriteLine(argumentException.Message);
        }
    }
}

