using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personArgs = Console.ReadLine().Split(" ").ToArray();
                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                Person person = new Person(name, age);

                people.Add(person);
            }

            var filteredAndOrderedList = people.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();

            foreach (var person in filteredAndOrderedList)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

        }
    }
}
