using System;

namespace _05._Character_Stats
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int health = int.Parse(Console.ReadLine());
            int maximumHealth = int.Parse(Console.ReadLine());
            int energy = int.Parse(Console.ReadLine());
            int maximumEnergy = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: |{new string('|', health)}{new string('.',maximumHealth-health)}|");
            Console.WriteLine($"Energy: |{new string('|', energy)}{new string('.',maximumEnergy-energy)}|");
        }
    }
}
