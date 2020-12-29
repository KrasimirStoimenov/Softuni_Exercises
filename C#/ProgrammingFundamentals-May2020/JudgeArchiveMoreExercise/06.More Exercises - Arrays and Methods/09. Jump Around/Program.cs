using System;
using System.Linq;

namespace _09._Jump_Around
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Proccessing(arr);
        }

        static void Proccessing(int[] arr)
        {
            int sum = 0;
            int index = 0;
            while (true)
            {
                int currentJump = arr[index];
                sum += arr[index];
                if (index + currentJump > arr.Length - 1)
                {
                    index -= arr[index];
                    if (index < 0)
                    {
                        break;
                    }

                    continue;
                }
                else
                {
                    index += arr[index];
                }

            }

            Console.WriteLine(sum);
        }
    }
}
