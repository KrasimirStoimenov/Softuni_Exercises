using System;
using System.Linq;

namespace _02._Manipulate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Proccessing(input);
            PrintOutput(input);
        }

        static void PrintOutput(string[] input)
        {
            input = input.Where(e => !string.IsNullOrEmpty(e)).ToArray();
            Console.WriteLine(string.Join(", ", input));
        }

        static void Proccessing(string[] input)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "Reverse":
                        Array.Reverse(input);
                        break;
                    case "Distinct":
                        DistinctItemsFromArray(input);
                        break;
                    case "Replace":
                        ReplaceItemsInArray(input, command);
                        break;
                }
            }
        }

        static void ReplaceItemsInArray(string[] input, string[] command)
        {
            int index = int.Parse(command[1]);
            string word = command[2];
            if (index >= 0 && index < input.Length)
            {
                input[index] = word;
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
