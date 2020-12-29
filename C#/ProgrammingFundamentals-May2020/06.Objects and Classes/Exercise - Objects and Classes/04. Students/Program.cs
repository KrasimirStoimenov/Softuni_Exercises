using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            Proccesing(students);

            Console.WriteLine(string.Join(Environment.NewLine, students.OrderByDescending(g => g.Grade)));
        }

        static void Proccesing(List<Student> students)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] arguments = Console.ReadLine().Split().ToArray();

                Student student = new Student(arguments[0], arguments[1], double.Parse(arguments[2]));
                students.Add(student);
            }
        }
    }
    //class Student
    //{
    //    public string FirstName { get; set; }

    //    public string LastName { get; set; }

    //    public double Grade { get; set; }

    //    public Student(string first, string last, double grade)
    //    {
    //        this.FirstName = first;
    //        this.LastName = last;
    //        this.Grade = grade;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{FirstName} {LastName}: {Grade:F2}";
    //    }
    //}

}
