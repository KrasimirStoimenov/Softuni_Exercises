using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            try
            {
            AddPeopleToList(people);
            AddProductsToList(products);
            Processing(people, products);
            PrintOutput(people);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintOutput(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

        private static void Processing(List<Person> people, List<Product> products)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string personName = cmdArgs[0];
                string productName = cmdArgs[1];

                Person person = people.FirstOrDefault(x => x.Name == personName);
                Product product = products.FirstOrDefault(x => x.Name == productName);

                person.BuyProduct(product);
            }
        }

        private static void AddProductsToList(List<Product> products)
        {
            string[] inputArgs = ReadInputArgs();

            for (int i = 0; i < inputArgs.Length; i++)
            {
                string[] productArgs = inputArgs[i].Split("=").ToArray();
                string productName = productArgs[0];
                double productCost = double.Parse(productArgs[1]);

                Product product = new Product(productName, productCost);
                products.Add(product);
            }
        }

        private static void AddPeopleToList(List<Person> people)
        {
            string[] inputArgs = ReadInputArgs();

            for (int i = 0; i < inputArgs.Length; i++)
            {
                string[] personArgs = inputArgs[i].Split("=").ToArray();
                string personName = personArgs[0];
                double money = double.Parse(personArgs[1]);

                Person person = new Person(personName, money);
                people.Add(person);
            }
        }

        private static string[] ReadInputArgs() => Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
    }
}
