using System;
using System.Linq;

namespace _02._Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] particles = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cmdArgs.Length == 0)
                {
                    break;
                }

                switch (cmdArgs[0])
                {
                    case "Move":
                        int moveIndex = int.Parse(cmdArgs[2]);
                        if (moveIndex < 0 || moveIndex >= particles.Length)
                        {
                            continue;
                        }
                        if (cmdArgs[1] == "Left" && moveIndex == 0)
                        {
                            continue;
                        }
                        else if (cmdArgs[1] == "Right" && moveIndex == particles.Length - 1)
                        {
                            continue;
                        }
                        particles = GetParticlesArranged(particles, moveIndex, cmdArgs[1]);

                        break;
                    case "Check":
                        PrintCheckIssue(particles, cmdArgs[1]);
                        break;

                }
            }
            Console.WriteLine($"You crafted {string.Join("", particles)}!");
        }
        static void PrintCheckIssue(string[] particles, string evenOrOdd)
        {
            string result = string.Empty;
            if (evenOrOdd == "Even")
            {
                for (int i = 0; i < particles.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        result += particles[i] + " ";
                    }
                }

            }
            else if (evenOrOdd == "Odd")
            {
                for (int i = 0; i < particles.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        result += particles[i] + " ";
                    }
                }
            }
            Console.WriteLine(result);
        }
        static string[] GetParticlesArranged(string[] particles, int index, string leftOrRight)
        {

            if (leftOrRight == "Left")
            {
                string temp = particles[index];
                particles[index] = particles[index - 1];
                particles[index - 1] = temp;

            }
            else if (leftOrRight == "Right")
            {
                string temp = particles[index];
                particles[index] = particles[index + 1];
                particles[index + 1] = temp;
            }
            return particles;
        }
    }
}
