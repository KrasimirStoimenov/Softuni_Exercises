using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args.Split();
            string commandType = cmdArgs[0]+"Command";
            string[] commandArgs = cmdArgs.Skip(1).ToArray();

            ICommand command = null;

            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandType);
            command = Activator.CreateInstance(type) as ICommand;
            return command.Execute(commandArgs);
        }
    }
}
