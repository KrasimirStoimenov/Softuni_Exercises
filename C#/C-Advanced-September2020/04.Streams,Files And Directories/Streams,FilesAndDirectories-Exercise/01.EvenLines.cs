using System;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using var reader = new StreamReader("../../../text.txt");
            using var writer = new StreamWriter("../../../Output.txt");

            char[] bannedSymbols = new char[] { '-', ',', '.', '!', '?' };
            int lineCounter = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (lineCounter % 2 == 0)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (bannedSymbols.Contains(line[i]))
                        {
                            line = line.Replace(line[i], '@');
                        }
                    }
                    string[] lineArgs = line.Split(" ").Reverse().ToArray();

                    writer.WriteLine(string.Join(" ", lineArgs));

                }
                lineCounter++;
            }
        }
    }
}
