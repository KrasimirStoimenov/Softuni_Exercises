using System;
using System.Collections.Generic;

namespace _06._Students_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Students> studentsList = new List<Students>();
            ReadStudents(studentsList);
            PrintStudentsFromCurrentTown(studentsList);
        }

        static void PrintStudentsFromCurrentTown(List<Students> students)
        {
            string town = Console.ReadLine();
            foreach (Students student in students)
            {
                if (student.Hometown == town)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        static void ReadStudents(List<Students> studentsList)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();
                string firstName = cmdArgs[0];
                string lastName = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);
                string hometown = cmdArgs[3];
                bool studentExist = CheckIfStudentExist(studentsList, firstName, lastName, age, hometown);
                if (studentExist)
                {
                    continue;
                }
                else
                {
                    Students student = new Students(firstName, lastName, age, hometown);
                    studentsList.Add(student);
                }
            }
        }

        static bool CheckIfStudentExist(List<Students> students, string firstName, string lastName, int age, string town)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    student.Age = age;
                    student.Hometown = town;
                    return true;
                }
            }

            return false;
        }
    }
    //class Students
    //{
    //    public Students(string first, string last, int age, string home)
    //    {
    //        this.FirstName = first;
    //        this.LastName = last;
    //        this.Age = age;
    //        this.Hometown = home;
    //    }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public int Age { get; set; }
    //    public string Hometown { get; set; }
    //}
}
