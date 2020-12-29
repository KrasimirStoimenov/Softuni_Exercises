using System;
using System.Linq;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = Console.ReadLine().Split("\\");

            string[] path = file.Last().Split(".");
            string fileName = path[0];
            string extension = path[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
