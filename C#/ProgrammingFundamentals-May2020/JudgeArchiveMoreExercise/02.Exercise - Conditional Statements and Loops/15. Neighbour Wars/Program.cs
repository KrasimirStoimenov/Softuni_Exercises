using System;

namespace _15._Neighbour_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            int peshoDamage = int.Parse(Console.ReadLine());
            int goshoDamage = int.Parse(Console.ReadLine());

            int peshoHealth = 100;
            int goshoHealth = 100;
            int roundCounter = 0;
            string currentAttacker = string.Empty;
            string currentDefender = string.Empty;
            string currentSpell = string.Empty;
            int currentHealth = 0;

            while (true)
            {
                roundCounter++;
                if (roundCounter % 2 != 0)
                {
                    goshoHealth -= peshoDamage;
                    currentAttacker = "Pesho";
                    currentDefender = "Gosho";
                    currentSpell = "Roundhouse kick";
                    currentHealth = goshoHealth;
                }
                else
                {
                    peshoHealth -= goshoDamage;
                    currentAttacker = "Gosho";
                    currentDefender = "Pesho";
                    currentSpell = "Thunderous fist";
                    currentHealth = peshoHealth;
                }

                if (peshoHealth <= 0)
                {
                    Console.WriteLine($"Gosho won in {roundCounter}th round.");
                    break;
                }
                else if (goshoHealth <= 0)
                {
                    Console.WriteLine($"Pesho won in {roundCounter}th round.");
                    break;
                }

                if (roundCounter % 3 == 0)
                {
                    goshoHealth += 10;
                    peshoHealth += 10;
                }

                Console.WriteLine($"{currentAttacker} used {currentSpell} and reduced {currentDefender} to {currentHealth} health.");

            }
        }
    }
}
