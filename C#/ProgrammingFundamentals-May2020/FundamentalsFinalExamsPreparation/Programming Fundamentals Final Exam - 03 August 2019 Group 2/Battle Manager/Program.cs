using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            ProccessingWithCommands(people);
            PrintOutput(people);
        }

        static void PrintOutput(List<Person> people)
        {
            Console.WriteLine($"People count: {people.Count}");

            foreach (var person in people.OrderByDescending(x=>x.Health).ThenBy(x=>x.Name))
            {
                Console.WriteLine(person.ToString());
            }

        }

        static void ProccessingWithCommands(List<Person> people)
        {
            string command;
            while ((command = Console.ReadLine()) != "Results")
            {
                string[] cmdArgs = command.Split(":");
                string action = cmdArgs[0];
                string user = cmdArgs[1];

                switch (action)
                {
                    case "Add":
                        AddPersonToList(people, cmdArgs, user);
                        break;
                    case "Attack":
                        AttackPerson(people, cmdArgs, user);
                        break;
                    case "Delete":
                        DeletePerson(people, user);
                        break;
                }
            }
        }

        static void DeletePerson(List<Person> people, string user)
        {
            if (user == "All")
            {
                people.Clear();
            }
            else if (CheckIfPersonExist(people, user))
            {
                Person current = people.Find(x => x.Name == user);
                people.Remove(current);
            }
        }

        static void AttackPerson(List<Person> people, string[] cmdArgs, string attackerName)
        {
            string defenderName = cmdArgs[2];
            int damage = int.Parse(cmdArgs[3]);
            bool hasAttackerExist = CheckIfPersonExist(people, attackerName);
            bool hasDefenderExist = CheckIfPersonExist(people, defenderName);

            if (hasAttackerExist && hasDefenderExist)
            {
                Person defender = people.Find(x => x.Name == defenderName);
                Person attacker = people.Find(x => x.Name == attackerName);

                defender.Health -= damage;
                if (defender.Health <= 0)
                {
                    people.Remove(defender);
                    Console.WriteLine($"{defenderName} was disqualified!");
                }

                attacker.Energy -= 1;
                if (attacker.Energy == 0)
                {
                    people.Remove(attacker);
                    Console.WriteLine($"{attackerName} was disqualified!");
                }
            }
        }

        static void AddPersonToList(List<Person> people, string[] cmdArgs, string user)
        {
            int health = int.Parse(cmdArgs[2]);
            int energy = int.Parse(cmdArgs[3]);

            if (CheckIfPersonExist(people, user))
            {
                Person current = people.Find(x => x.Name == user);
                current.Health += health;
            }
            else
            {
                Person person = new Person(user, health, energy);
                people.Add(person);
            }
        }

        static bool CheckIfPersonExist(List<Person> people, string user)
        {
            Person current = people.Find(x => x.Name == user);
            if (current == null)
            {
                return false;
            }

            return true;

        }
    }
    //class Person
    //{
    //    public string Name { get; set; }
    //    public int Health { get; set; }
    //    public int Energy { get; set; }

    //    public Person(string name, int health, int energy)
    //    {
    //        this.Name = name;
    //        this.Health = health;
    //        this.Energy = energy;
    //    }
    //    public override string ToString()
    //    {
    //        return $"{Name} - {Health} - {Energy}";
    //    }
    //}

}
