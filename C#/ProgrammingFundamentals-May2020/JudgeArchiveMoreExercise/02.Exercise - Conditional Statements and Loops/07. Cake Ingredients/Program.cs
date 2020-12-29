using System;

namespace _07._Cake_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string ingredient;
            while ((ingredient = Console.ReadLine()) != "Bake!")
            {
                Console.WriteLine($"Adding ingredient {ingredient}.");
                counter++;
            }

            Console.WriteLine($"Preparing cake with {counter} ingredients.");
        }
    }
}
