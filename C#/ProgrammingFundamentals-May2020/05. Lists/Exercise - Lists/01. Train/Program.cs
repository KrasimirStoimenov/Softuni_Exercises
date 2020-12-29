using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int wagonsCappacity = int.Parse(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();
                if (cmdArgs[0] == "Add")
                {
                    AddWagons(wagons, int.Parse(cmdArgs[1]));
                }
                else
                {
                    PutPeopleInWagons(wagons, int.Parse(cmdArgs[0]), wagonsCappacity);
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        static void AddWagons(List<int> wagons, int people)
        {
            wagons.Add(people);
        }
        static void PutPeopleInWagons(List<int> wagons, int people, int wagonsCappacity)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                if (wagons[i] + people <= wagonsCappacity)
                {
                    wagons[i] += people;
                    break;
                }
            }
        }
    }
}
