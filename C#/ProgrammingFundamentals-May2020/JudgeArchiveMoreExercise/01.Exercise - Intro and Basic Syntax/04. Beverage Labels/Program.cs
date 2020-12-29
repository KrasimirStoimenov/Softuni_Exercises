using System;

namespace _04._Beverage_Labels
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            double energyContent = double.Parse(Console.ReadLine());
            double sugarContents = double.Parse(Console.ReadLine());

            Console.WriteLine($"{quantity}ml {product}:");
            Console.WriteLine($"{energyContent*quantity/100}kcal, {sugarContents*quantity/100}g sugars");

        }
    }
}
