using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initialSongs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<string> songQueue = new Queue<string>(initialSongs);

            while (songQueue.Any())
            {
                string command = Console.ReadLine();
                if (command.StartsWith("Add"))
                {
                    string song = command.Substring(4);

                    if (songQueue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songQueue.Enqueue(song);
                    }
                }
                else if (command.StartsWith("Show"))
                {
                    Console.WriteLine(string.Join(", ", songQueue));
                }
                else
                {
                    songQueue.Dequeue();
                }
            }

            Console.WriteLine($"No more songs!");
        }
    }
}
