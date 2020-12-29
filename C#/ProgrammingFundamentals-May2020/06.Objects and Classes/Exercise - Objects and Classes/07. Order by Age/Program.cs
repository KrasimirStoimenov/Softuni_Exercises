using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            Proccessing(people);
            PrintOutput(people);
        }

        static void PrintOutput(List<Person> people)
        {
            Console.WriteLine(string.Join(Environment.NewLine, people.OrderBy(x => x.Age)));
        }

        static void Proccessing(List<Person> people)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string name = cmdArgs[0];
                string id = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);

                Person person = new Person(name, id, age);
                people.Add(person);
            }
        }
    }
    //class Person
    //{
    //    public string Name { get; set; }
    //    public string ID { get; set; }
    //    public int Age { get; set; }

    //    public Person(string name, string id, int age)
    //    {
    //        this.Name = name;
    //        this.ID = id;
    //        this.Age = age;
    //    }
    //    public override string ToString()
    //    {
    //        return $"{this.Name} with ID: {this.ID} is {this.Age} years old.";
    //    }
    //}
}
