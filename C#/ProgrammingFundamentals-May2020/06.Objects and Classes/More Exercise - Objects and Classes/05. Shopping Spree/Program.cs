using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleList = new List<Person>();
            List<Product> productList = new List<Product>();

            FillPeopleList(peopleList);
            FillProductList(productList);


            Proccessing(peopleList, productList);

            Console.WriteLine(string.Join(Environment.NewLine, peopleList));

        }
        static void Proccessing(List<Person> peopleList, List<Product> productList)
        {

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split();
                string name = cmdArgs[0];
                string productName = cmdArgs[1];

                Person currentPerson = peopleList.Find(x => x.Name == name);
                Product currentProduct = productList.Find(x => x.Name == productName);

                if (currentPerson.Money >= currentProduct.Price)
                {
                    currentPerson.Money -= currentProduct.Price;
                    currentPerson.Products.Add(productName);

                    Console.WriteLine($"{name} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{currentPerson.Name} can't afford {productName}");
                }

            }
        }

        static void FillProductList(List<Product> productList)
        {
            string[] products = Console.ReadLine().Split(";");
            products = products.Where(x => x != "").ToArray();
            for (int i = 0; i < products.Length; i++)
            {
                string[] args = products[i].Split("=");
                string name = args[0];
                decimal price = decimal.Parse(args[1]);

                Product product = new Product(name, price);
                productList.Add(product);

            }
        }

        static void FillPeopleList(List<Person> peopleList)
        {
            string[] people = Console.ReadLine().Split(";");

            for (int i = 0; i < people.Length; i++)
            {
                string[] args = people[i].Split("=");
                string name = args[0];
                decimal money = decimal.Parse(args[1]);

                Person person = new Person(name, money);
                peopleList.Add(person);

            }

        }

    }
    //class Person
    //{
    //    public string Name { get; set; }

    //    public decimal Money { get; set; }

    //    public List<string> Products;

    //    public Person(string name, decimal money)
    //    {
    //        this.Name = name;
    //        this.Money = money;
    //        Products = new List<string>();
    //    }

    //    public override string ToString()
    //    {
    //        if (this.Products.Count == 0)
    //        {
    //            return $"{this.Name} - Nothing bought";

    //        }
    //        return $"{this.Name} - {string.Join(", ", Products)}";
    //    }

    //}
    //class Product
    //{
    //    public string Name { get; set; }

    //    public decimal Price { get; set; }

    //    public Product(string name, decimal price)
    //    {
    //        this.Name = name;
    //        this.Price = price;
    //    }
    //}


}
