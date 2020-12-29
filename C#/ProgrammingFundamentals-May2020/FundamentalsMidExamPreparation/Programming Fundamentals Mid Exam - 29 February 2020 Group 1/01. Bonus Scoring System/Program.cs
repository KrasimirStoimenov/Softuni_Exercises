using System;

namespace _01._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int initialBonus = int.Parse(Console.ReadLine());

            double maxScore = 0;
            double maxAttendance = 0;
            for (int i = 0; i < studentsCount; i++)
            {
                double attendedLectures = double.Parse(Console.ReadLine());
                double bonus = attendedLectures / lecturesCount * (5 + initialBonus);
                if (bonus > maxScore)
                {
                    maxScore = bonus;
                    maxAttendance = attendedLectures;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Round(maxScore)}.");
            Console.WriteLine($"The student has attended {maxAttendance} lectures.");

        }
    }
}
