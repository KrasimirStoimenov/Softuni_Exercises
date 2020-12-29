using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            Proccessing(courses);

            PrintOutput(courses);
        }

        static void PrintOutput(Dictionary<string, List<string>> courses)
        {
            courses = courses.OrderByDescending(x => x.Value.Count).ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in courses)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                List<string> orderedList = kvp.Value.OrderBy(n => n).ToList();

                for (int i = 0; i < orderedList.Count; i++)
                {
                    Console.WriteLine($"-- {orderedList[i]}");

                }
            }

        }

        static void Proccessing(Dictionary<string, List<string>> courses)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split(" : ");
                string course = cmdArgs[0];
                string student = cmdArgs[1];

                if (courses.ContainsKey(course))
                {
                    courses[course].Add(student);
                }
                else
                {
                    courses.Add(course, new List<string>() { student });
                }

            }
        }
    }
}
