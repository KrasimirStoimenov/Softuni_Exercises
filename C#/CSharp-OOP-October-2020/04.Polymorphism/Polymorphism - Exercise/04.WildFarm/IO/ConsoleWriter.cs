using System;

using _04.WildFarm.IO.Contracts;

namespace _04.WildFarm.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(char symbol)
        {
            Console.Write(symbol);
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
