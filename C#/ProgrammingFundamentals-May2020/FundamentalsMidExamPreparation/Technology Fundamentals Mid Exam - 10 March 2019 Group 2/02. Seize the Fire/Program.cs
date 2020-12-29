using System;
using System.Collections.Generic;
namespace _02._Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fireCells = Console.ReadLine()
                .Split("#");

            int water = int.Parse(Console.ReadLine());
            double effort = 0;
            int totalFire = 0;
            List<int> cells = new List<int>();

            for (int i = 0; i < fireCells.Length; i++)
            {
                string[] fireCellsArgs = fireCells[i].Split(" = ");

                string level = fireCellsArgs[0];
                int range = int.Parse(fireCellsArgs[1]);

                if (range > water)
                {
                    continue;
                }
                switch (level)
                {
                    case "High":
                        if (range <= 125 && range >= 81)
                        {
                            water -= range;
                            effort += range * 0.25;
                            cells.Add(range);
                            totalFire += range;
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "Medium":
                        if (range <= 80 && range >= 51)
                        {
                            water -= range;
                            effort += range * 0.25;
                            cells.Add(range);
                            totalFire += range;
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "Low":
                        if (range <= 50 && range >= 1)
                        {
                            water -= range;
                            effort += range * 0.25;
                            cells.Add(range);
                            totalFire += range;
                        }
                        else
                        {
                            continue;
                        }
                        break;

                }

                if (water <= 0)
                {
                    break;
                }
            }

            Console.WriteLine("Cells:");
            foreach (var cell in cells)
            {
                Console.WriteLine($" - {cell}");
            }
            Console.WriteLine($"Effort: {effort:F2}");
            Console.WriteLine($"Total Fire: {totalFire}");

        }
    }
}
