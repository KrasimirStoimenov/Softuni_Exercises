using System;

namespace _05._Boolean_Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            bool converted = Convert.ToBoolean(input);
            if (converted)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
