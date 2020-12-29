using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {

            using var reader = new StreamReader("../../../Input.txt");
            using var writer = new StreamWriter("../../../Output.txt");

            int lineCounter = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (lineCounter % 2 != 0)
                {
                    writer.WriteLine(line);
                }

                lineCounter++;
            }
        }
    }
}
