using System;
using System.Collections.Generic;
using System.Linq;
using _03.Raiding.Core.Contracts;
using _03.Raiding.Factory;
using _03.Raiding.Models.Contracts;

namespace _03.Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<IHero> heroes;
        private readonly HeroFactory factory;
        public Engine()
        {
            this.heroes = new List<IHero>();
            this.factory = new HeroFactory();
        }

        public void Run()
        {
            AddHeroes();
            PrintOutput();
        }

        private void PrintOutput()
        {
            int bossHealth = int.Parse(Console.ReadLine());
            int powerOfHeroes = this.heroes.Sum(p => p.Power);
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
            if (powerOfHeroes >= bossHealth)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private void AddHeroes()
        {
            int heroesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < heroesCount; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                if (IsValidHeroType(heroType))
                {
                    heroes.Add(this.factory.CreateHero(heroType, heroName));
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }
            }
        }

        private bool IsValidHeroType(string heroType)
        {
            if (heroType == "Druid" || heroType == "Paladin" || heroType == "Rogue" || heroType == "Warrior")
            {
                return true;
            }
            return false;
        }
    }
}
