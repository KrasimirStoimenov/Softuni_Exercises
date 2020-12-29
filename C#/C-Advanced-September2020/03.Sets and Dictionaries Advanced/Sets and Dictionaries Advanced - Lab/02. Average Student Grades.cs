using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentsInfo = new Dictionary<string, List<decimal>>();

            AddingStudentsInfoInDictionary(studentsCount, studentsInfo);
            PrintOutput(studentsInfo);
        }

        static void PrintOutput(Dictionary<string, List<decimal>> studentsInfo)
        {
            foreach (var kvp in studentsInfo)
            {
                string[] formattedGrades = kvp.Value.Select(x => string.Format("{0:0.00}", x)).ToArray();
                Console.WriteLine($"{kvp.Key} -> {string.Join(" ", formattedGrades)} (avg: {kvp.Value.Average():F2})");
            }
        }

        static void AddingStudentsInfoInDictionary(int studentsCount, Dictionary<string, List<decimal>> studentsInfo)
        {
            for (int i = 0; i < studentsCount; i++)
            {
                string[] studentArgs = Console.ReadLine().Split(" ").ToArray();
                string student = studentArgs[0];
                decimal grade = decimal.Parse(studentArgs[1]);

                if (!studentsInfo.ContainsKey(student))
                {
                    studentsInfo.Add(student, new List<decimal>());
                }

                studentsInfo[student].Add(grade);
            }
        }
    }
}
