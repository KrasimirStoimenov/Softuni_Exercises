using System;
using System.Linq;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] arr = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            Proccessing(arr);

            Console.WriteLine(string.Join(", ", arr));
        }

        static void Proccessing(long[] arr)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();

                switch (cmdArgs[0])
                {
                    case "swap":
                        int firstIndexToSwap = int.Parse(cmdArgs[1]);
                        int secondIndexToSwap = int.Parse(cmdArgs[2]);

                        long temp = arr[firstIndexToSwap];
                        arr[firstIndexToSwap] = arr[secondIndexToSwap];
                        arr[secondIndexToSwap] = temp;
                        break;
                    case "multiply":
                        int firstIndex = int.Parse(cmdArgs[1]);
                        int secondIndex = int.Parse(cmdArgs[2]);

                        arr[firstIndex] = arr[firstIndex] * arr[secondIndex];
                        break;
                    case "decrease":
                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i] -= 1;
                        }

                        break;

                }
            }
        }
    }
}
