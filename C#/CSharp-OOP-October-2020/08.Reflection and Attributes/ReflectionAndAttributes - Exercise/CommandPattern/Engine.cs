using System;

using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine(commandInterpreter.Read(input));
            }

        }
    }
}
