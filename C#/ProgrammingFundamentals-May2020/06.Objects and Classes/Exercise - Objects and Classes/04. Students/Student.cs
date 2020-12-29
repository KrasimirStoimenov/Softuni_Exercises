using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Students
{
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }

        public Student(string first, string last, double grade)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }
}
