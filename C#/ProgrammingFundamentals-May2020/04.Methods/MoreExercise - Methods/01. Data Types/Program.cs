using System;

namespace _01._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string result = GetResult(input);
            Console.WriteLine(result);
        }
        static string GetResult(string input)
        {
            string result = string.Empty;

            switch (input)
            {
                case "int":
                    int num = int.Parse(Console.ReadLine());
                    result = (num * 2).ToString();
                    break;
                case "real":
                    double realNum = double.Parse(Console.ReadLine());
                    result = $"{(realNum * 1.5):F2}".ToString();
                    break;
                case "string":
                    string word = Console.ReadLine();
                    result = $"${word}$";
                    break;
            }
            return result;
        }
    }
}
