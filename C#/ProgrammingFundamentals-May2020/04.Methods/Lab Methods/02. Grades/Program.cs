﻿using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            float grade = float.Parse(Console.ReadLine());

            PrintResult(grade);
        }
        static void PrintResult(float grade)
        {
            if (grade >= 5.50 && grade <= 6.00)
            {
                Console.WriteLine("Excellent");
            }
            else if (grade >= 4.50)
            {
                Console.WriteLine("Very good");
            }
            else if (grade >= 3.50)
            {
                Console.WriteLine("Good");
            }
            else if (grade >= 3.00)
            {
                Console.WriteLine("Poor");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }
    }
}
