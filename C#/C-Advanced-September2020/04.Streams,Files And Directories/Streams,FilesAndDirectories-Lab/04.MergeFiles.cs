using System;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using var firstFileReader = new StreamReader("../../../FileOne.txt");
            using var secondFileReader = new StreamReader("../../../FileTwo.txt");
            using var writer = new StreamWriter("../../../Output.txt");
            //Condition they are equal

            string line;
            while ((line = firstFileReader.ReadLine()) != null)
            {
                string secondLine = secondFileReader.ReadLine();

                writer.WriteLine(line);
                writer.WriteLine(secondLine);
            }
        }
    }
}
