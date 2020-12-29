using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int[] bombAndPower = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int bomb = bombAndPower[0];
            int power = bombAndPower[1];

            while (numbers.Contains(bomb))
            {
                int bombIndex = 0;
                bombIndex = GetBombIndex(numbers, bomb, bombIndex);

                RemoveRightPower(numbers, power, bombIndex);
                RemoveLeftPower(numbers, power, bombIndex);

            }

            Console.WriteLine(numbers.Sum());
        }

        private static void RemoveLeftPower(List<int> list, int power, int bombIndex)
        {
            for (int i = bombIndex - 1; i >= bombIndex - power; i--)
            {
                if (i >= 0)
                {
                    list.RemoveAt(i);
                }
            }
        }

        private static void RemoveRightPower(List<int> list, int power, int bombIndex)
        {
            for (int i = 0; i <= power; i++)
            {
                if (list.Count > bombIndex)
                {
                    list.RemoveAt(bombIndex);
                }

            }
        }

        private static int GetBombIndex(List<int> list, int bomb, int bombIndex)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == bomb)
                {
                    bombIndex = i;
                    break;
                }
            }

            return bombIndex;
        }
    }
}
