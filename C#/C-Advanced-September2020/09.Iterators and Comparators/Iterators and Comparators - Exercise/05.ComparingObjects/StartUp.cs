using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                string town = inputArgs[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            int indexOfPersonToCompare = int.Parse(Console.ReadLine());

            Person currentPerson = people[indexOfPersonToCompare-1];
            int matches = 0;

            foreach (var person in people)
            {
                if (currentPerson.CompareTo(person) == 0)
                {
                    matches++;
                }
            }

            if (matches <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {people.Count-matches} {people.Count}");
            }
        }
    }
}
