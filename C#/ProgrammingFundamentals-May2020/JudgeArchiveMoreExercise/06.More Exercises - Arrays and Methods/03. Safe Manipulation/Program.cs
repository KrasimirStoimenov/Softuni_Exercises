using System;
using System.Linq;

namespace _03._Safe_Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Proccessing(input);
        }

        static void Proccessing(string[] input)
        {
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split();
                input = input.Where(e => !string.IsNullOrEmpty(e)).ToArray();

                switch (cmdArgs[0])
                {
                    case "Reverse":
                        Array.Reverse(input);
                        break;
                    case "Distinct":
                        DistinctItemsFromArray(input);
                        input = input.Where(e => !string.IsNullOrEmpty(e)).ToArray();
                        break;
                    case "Replace":
                        ReplaceItemsInArray(input, cmdArgs);
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", input));
        }

        static void ReplaceItemsInArray(string[] input, string[] command)
        {
            int index = int.Parse(command[1]);
            string word = command[2];
            if (index >= 0 && index < input.Length)
            {
                input[index] = word;
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }

        static void DistinctItemsFromArray(string[] input)
        {
            for (int j = 0; j < input.Length; j++)
            {
                for (int k = j + 1; k < input.Length; k++)
                {
                    if (input[j] == input[k])
                    {
                        input[k] = string.Empty;
                    }
                }
            }

        }
    }
}
