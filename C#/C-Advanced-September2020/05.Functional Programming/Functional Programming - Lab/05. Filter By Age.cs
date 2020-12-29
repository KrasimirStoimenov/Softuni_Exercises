using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            FillPeopleDict(people);


            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            Func<Person, bool> ageFilter = ConditionFilter(condition, age);
            string outputCondition = Console.ReadLine();
            Action<Person> printOutput = CreatePrinter(outputCondition);

            people.Where(ageFilter).ToList().ForEach(printOutput);
        }


        static Action<Person> CreatePrinter(string outputCondition)
        {
            switch (outputCondition)
            {
                case "name": return x => Console.WriteLine($"{x.Name}");
                case "age": return x => Console.WriteLine($"{x.Age}");
                case "name age": return x => Console.WriteLine($"{x.Name} - {x.Age}");
                default:
                    return null;
            }
        }

        static Func<Person, bool> ConditionFilter(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x.Age < age;
                case "older":
                    return x => x.Age > age;
                default:
                    return null;
            }
        }

        private static void FillPeopleDict(List<Person> people)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var personArgs = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                Person person = new Person()
                {
                    Name = name,
                    Age = age
                };

                people.Add(person);
            }
        }
    }
    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

    }
}
