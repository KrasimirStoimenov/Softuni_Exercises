using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            Proccessing(students);
            Dictionary<string, double> studentsWithAverage = GetAverageGradesToAllStudents(students);
            PrintOutput(studentsWithAverage);
        }

        static void PrintOutput(Dictionary<string, double> studentsWithAverage)
        {
            studentsWithAverage = studentsWithAverage
                .Where(x => x.Value >= 4.50)
                .OrderByDescending(x => x.Value)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in studentsWithAverage)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:f2}");
            }

        }

        static Dictionary<string, double> GetAverageGradesToAllStudents(Dictionary<string, List<double>> students)
        {
            Dictionary<string, double> averageGrades = new Dictionary<string, double>();

            foreach (var kvp in students)
            {
                double averageGrade = kvp.Value.Sum() / kvp.Value.Count;

                averageGrades.Add(kvp.Key, averageGrade);
            }
            return averageGrades;
        }

        static void Proccessing(Dictionary<string, List<double>> students)
        {
            int countPairs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countPairs; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(studentName))
                {
                    students[studentName].Add(grade);
                }
                else
                {
                    students.Add(studentName, new List<double>() { grade });
                }
            }
        }
    }
}
