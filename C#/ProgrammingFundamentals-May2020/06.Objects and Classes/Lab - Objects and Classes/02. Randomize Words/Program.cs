using System;

namespace _02._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Random random = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                int index = random.Next(0, input.Length);

                string temp = input[i];
                input[i] = input[index];
                input[index] = temp;
            }

            Console.WriteLine(string.Join("\n", input));
        }
    }
}
