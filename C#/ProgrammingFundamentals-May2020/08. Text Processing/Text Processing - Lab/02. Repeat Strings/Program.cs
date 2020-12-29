using System;
using System.Linq;
using System.Text;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split(" ")
                .ToArray();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    sb.Append(arr[i]);
                }
            }

            Console.WriteLine(sb);

        }
    }
}
