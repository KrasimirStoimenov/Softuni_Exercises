using System;
using System.Linq;

namespace _10._LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            short sizeOfField = short.Parse(Console.ReadLine());
            int[] inintialIndexes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] ladybugIndexes = GetLadybugIndexes(sizeOfField, inintialIndexes);

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command
                    .Split(' ')
                    .ToArray();

                int ladybugIndex = int.Parse(cmdArgs[0]);
                string side = cmdArgs[1];
                int moves = int.Parse(cmdArgs[2]);

                if (ladybugIndex < 0 || ladybugIndex > sizeOfField)
                {
                    continue;
                }
                if (ladybugIndexes[ladybugIndex] == 0)
                {
                    continue;
                }

                if (side == "right")
                {
                    while (ladybugIndexes[moves] == 1)
                    {
                        moves += moves;
                        if (ladybugIndexes.Length + moves > ladybugIndexes.Length || ladybugIndexes.Length + moves < 0)
                        {
                            break;
                        }

                    }
                    if (ladybugIndexes.Length + moves > ladybugIndexes.Length || ladybugIndexes.Length + moves < 0)
                    {
                        ladybugIndexes[ladybugIndex] = 0;
                        continue;
                    }
                    ladybugIndexes[ladybugIndex] = 0;
                    ladybugIndexes[ladybugIndex + moves] = 1;
                }
                else if (side == "left")
                {
                    if (ladybugIndexes.Length - moves > ladybugIndexes.Length || ladybugIndexes.Length - moves < 0)
                    {
                        ladybugIndexes[ladybugIndex] = 0;
                        continue;
                    }
                    while (ladybugIndexes[moves] == 1)
                    {
                        moves -= moves;
                        if (ladybugIndexes.Length - moves > ladybugIndexes.Length || ladybugIndexes.Length - moves < 0)
                        {
                            break;
                        }

                    }
                    if (ladybugIndexes.Length - moves > ladybugIndexes.Length || ladybugIndexes.Length - moves < 0)
                    {
                        ladybugIndexes[ladybugIndex] = 0;
                        continue;
                    }
                    ladybugIndexes[ladybugIndex] = 0;
                    ladybugIndexes[ladybugIndex - moves] = 1;
                }
            }
            Console.WriteLine(string.Join(' ', ladybugIndexes));

        }
        static int[] GetLadybugIndexes(short sizeOfField, int[] initialIndexes)
        {
            int[] ladybugIndexes = new int[sizeOfField];

            for (int i = 0; i < sizeOfField; i++)
            {
                if (initialIndexes.Contains(i))
                {
                    ladybugIndexes[i] = 1;
                }
            }
            return ladybugIndexes;
        }
    }
}
