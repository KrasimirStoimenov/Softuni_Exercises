using System;

namespace _06._Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "USA":
                case "England":
                    Console.WriteLine("English");
                    break;
                case "Spain":
                case "Mexico":
                case "Argentina":
                    Console.WriteLine("Spanish");
                    break;
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
