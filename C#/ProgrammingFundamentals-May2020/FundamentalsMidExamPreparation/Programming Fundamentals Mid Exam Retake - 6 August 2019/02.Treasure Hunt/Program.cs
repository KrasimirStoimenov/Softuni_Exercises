using System;
using System.Collections.Generic;
using System.Linq;
namespace _02.Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treasureList = Console.ReadLine()
                .Split("|")
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] cmdArgs = command.Split(" ");

                switch (cmdArgs[0])
                {
                    case "Loot":
                        Loot(treasureList, cmdArgs);
                        break;
                    case "Drop":
                        Drop(treasureList, cmdArgs);
                        break;
                    case "Steal":
                        Steal(treasureList, cmdArgs);
                        break;
                }
            }
            if (treasureList.Any())
            {
                double sumTreasure = 0;
                for (int i = 0; i < treasureList.Count; i++)
                {
                    sumTreasure += treasureList[i].Length;
                }

                Console.WriteLine($"Average treasure gain: {sumTreasure / treasureList.Count:F2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }


        static void Loot(List<string> treasureList, string[] cmdArgs)
        {
            for (int i = 1; i < cmdArgs.Length; i++)
            {
                if (treasureList.Contains(cmdArgs[i]))
                {
                    continue;
                }
                else
                {
                    treasureList.Insert(0, cmdArgs[i]);
                }
            }
        }

        static void Drop(List<string> treasureList, string[] cmdArgs)
        {
            int index = int.Parse(cmdArgs[1]);
            if (index >= 0 && index < treasureList.Count)
            {
                string temp = treasureList[index];
                treasureList.RemoveAt(index);
                treasureList.Add(temp);
            }
        }

        static void Steal(List<string> treasureList, string[] cmdArgs)
        {
            List<string> stolenTreasure = new List<string>();
            int count = int.Parse(cmdArgs[1]);
            treasureList.Reverse();
            if (count >= treasureList.Count)
            {
                if (treasureList.Any())
                {
                    treasureList.Reverse();
                    Console.WriteLine(string.Join(", ", treasureList));
                    treasureList.RemoveRange(0, treasureList.Count);
                }   
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    stolenTreasure.Insert(0, treasureList[i]);
                }

                treasureList.RemoveRange(0, count);
                treasureList.Reverse();
                Console.WriteLine(string.Join(", ", stolenTreasure));
            }

        }
    }
}
