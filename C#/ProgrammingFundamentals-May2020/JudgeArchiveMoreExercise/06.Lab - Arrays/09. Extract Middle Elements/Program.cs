using System;

namespace _09._Extract_Middle_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split();

            if (array.Length == 1)
            {
                Console.WriteLine($"{{ {string.Join("", array)} }}");
            }
            else
            {
                Console.WriteLine($"{{ {ExtractMiddleElements(array)} }}");
            }


        }
        static string ExtractMiddleElements(string[] array)
        {
            string result = string.Empty;
            if (array.Length % 2 == 0)
            {
                string[] resultArr = new string[2];
                resultArr[0] = array[array.Length / 2 - 1];
                resultArr[1] = array[array.Length / 2];
                result = string.Join(", ", resultArr);

            }
            else
            {
                string[] resultArr = new string[3];
                resultArr[0] = array[array.Length / 2 - 1];
                resultArr[1] = array[array.Length / 2];
                resultArr[2] = array[array.Length / 2 + 1];
                result = string.Join(", ", resultArr);
            }

            return result;
        }

    }
}
