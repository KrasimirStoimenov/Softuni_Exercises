using System;
using System.Linq;

namespace _01._Encrypt__Sort_and_Print_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] sumArr = new int[count];

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                int sum = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    char currentChar = input[j];
                    switch (char.ToLower(currentChar))                //A, E, I, O, U, sometimes 'Y'
                    {
                        case 'a':
                        case 'e':
                        case 'i':
                        case 'o':
                        case 'u':
                            sum += (int)input[j] * input.Length;
                            break;
                        default:
                            sum += (int)input[j] / input.Length;
                            break;
                    }
                }
                sumArr[i] = sum;
            }

            sumArr = sumArr.OrderBy(x => x).ToArray();
            Console.WriteLine(string.Join("\n", sumArr));
        }
    }
}
