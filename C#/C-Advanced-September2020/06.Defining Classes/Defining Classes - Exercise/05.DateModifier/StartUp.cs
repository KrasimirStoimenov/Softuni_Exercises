using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();
            int days = dateModifier.CalculateDays(firstDate, secondDate);

            Console.WriteLine(days);
        }
    }
}
