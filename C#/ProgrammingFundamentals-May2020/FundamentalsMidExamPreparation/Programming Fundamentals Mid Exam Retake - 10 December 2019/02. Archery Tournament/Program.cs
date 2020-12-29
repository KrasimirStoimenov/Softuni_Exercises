using System;
using System.Linq;

namespace _02._Archery_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int points = 0;
            Proccessing(ref targets, ref points);

            Console.WriteLine(string.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }

        static void Proccessing(ref int[] targets, ref int points)
        {
            string command;
            while ((command = Console.ReadLine()) != "Game over")
            {
                string[] cmdArgs = command
                    .Split(new char[] { '@', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs[0] == "Reverse")
                {
                    targets = targets.Reverse().ToArray();
                    continue;
                }
                if (int.Parse(cmdArgs[2]) < 0 || int.Parse(cmdArgs[2]) >= targets.Length)
                {
                    continue;
                }
                if (cmdArgs[1] == "Left")
                {
                    GetTargetsProccessedLeft(targets, ref points, int.Parse(cmdArgs[2]), int.Parse(cmdArgs[3]));
                }
                else if (cmdArgs[1] == "Right")
                {
                    GetTargetsProccessedRight(targets, ref points, int.Parse(cmdArgs[2]), int.Parse(cmdArgs[3]));
                }
            }
        }
        static void GetTargetsProccessedLeft(int[] targets, ref int points, int startIndex, int length)
        {
            while (length != 0)
            {

                if (startIndex > 0)
                {
                    startIndex--;
                    length--;
                }
                else if (startIndex == 0)
                {
                    startIndex = targets.Length - 1;
                    length--;
                }
            }

            if (targets[startIndex] >= 5)
            {
                targets[startIndex] -= 5;
                points += 5;
            }
            else
            {
                points += targets[startIndex];
                targets[startIndex] = 0;
            }
        }
        static void GetTargetsProccessedRight(int[] targets, ref int points, int startIndex, int length)
        {
            while (length != 0)
            {

                if (startIndex < targets.Length-1)
                {
                    startIndex++;
                    length--;
                }
                else if (startIndex == targets.Length-1)
                {
                    startIndex = 0;
                    length--;
                }
            }
            if (targets[startIndex] >= 5)
            {
                targets[startIndex] -= 5;
                points += 5;
            }
            else
            {
                points += targets[startIndex];
                targets[startIndex] = 0;
            }
        }
    }
}

