using System;
using System.Linq;

namespace _02._Shoot_for_the_Win
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Proccessing(targets);
            int[] shotTargets = targets.Where(x => x == -1).ToArray();
            Console.WriteLine($"Shot targets: {shotTargets.Length} -> {string.Join(" ", targets)}");

        }

        static void Proccessing(int[] targets)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                int indexToShoot = int.Parse(command);
                if (indexToShoot < 0 || indexToShoot >= targets.Length)
                {
                    continue;
                }
                if (targets[indexToShoot] == -1)
                {
                    continue;
                }
                int currentNumberStrength = targets[indexToShoot];
                targets[indexToShoot] = -1;

                AddAndReduceTargets(targets, currentNumberStrength);

            }
        }

        static void AddAndReduceTargets(int[] targets, int currentNumberStrength)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] == -1)
                {
                    continue;
                }
                else if (targets[i] > currentNumberStrength)
                {
                    targets[i] -= currentNumberStrength;
                }
                else if (targets[i] <= currentNumberStrength)
                {
                    targets[i] += currentNumberStrength;
                }
            }
        }
    }
}
