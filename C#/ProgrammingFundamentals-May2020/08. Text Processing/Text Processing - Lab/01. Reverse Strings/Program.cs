using System;
using System.Text;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                StringBuilder reversed = new StringBuilder();

                for (int i = command.Length - 1; i >= 0; i--)
                {
                    reversed.Append(command[i]);
                }

                Console.WriteLine($"{command} = {reversed}");
            }
        }
    }
}
