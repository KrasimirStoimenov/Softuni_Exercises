﻿using System;

namespace _01.Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysToPlunder = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            double totalPlunder = 0;
            for (int i = 1; i <= daysToPlunder; i++)
            {
                totalPlunder += dailyPlunder;

                if (i % 3 == 0)
                {
                    totalPlunder += dailyPlunder * 0.50;
                }
                if (i % 5 == 0)
                {
                    totalPlunder *= 0.70;
                }

            }
            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:F2} plunder gained.");
            }
            else
            {
                Console.WriteLine($"Collected only {totalPlunder / expectedPlunder * 100:F2}% of the plunder.");
            }
        }
    }
}

