using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("../../../Input.txt");
            using var writer = new StreamWriter("../../../Output.txt");

            int lineCounter = 1;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                writer.WriteLine($"{lineCounter}. {line}");
                lineCounter++;
            }

        }
    }
}
