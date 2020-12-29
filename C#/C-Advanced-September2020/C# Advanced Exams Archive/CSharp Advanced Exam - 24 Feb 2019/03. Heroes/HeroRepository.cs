using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    class HeroRepository
    {
        private List<Hero> heroes;
        public HeroRepository()
        {
            this.heroes = new List<Hero>();
        }

        public int Count { get => heroes.Count; }

        public void Add(Hero hero)
        {
            this.heroes.Add(hero);
        }

        public void Remove(string name)
        {
            var hero = heroes.FirstOrDefault(x => x.Name == name);
            heroes.Remove(hero);
        }
        public Hero GetHeroWithHighestStrength()
        {
            int maxStrength = int.MinValue;
            Hero bestHero = null;

            foreach (var hero in this.heroes)
            {
                if (hero.Item.Strength > maxStrength)
                {
                    maxStrength = hero.Item.Strength;
                    bestHero = hero;
                }
            }

            return bestHero;
        }
        public Hero GetHeroWithHighestAbility()
        {
            int maxAbility = int.MinValue;
            Hero bestHero = null;

            foreach (var hero in this.heroes)
            {
                if (hero.Item.Ability > maxAbility)
                {
                    maxAbility = hero.Item.Ability;
                    bestHero = hero;
                }
            }

            return bestHero;
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            int maxIntelligence = int.MinValue;
            Hero bestHero = null;

            foreach (var hero in this.heroes)
            {
                if (hero.Item.Intelligence > maxIntelligence)
                {
                    maxIntelligence = hero.Item.Intelligence;
                    bestHero = hero;
                }
            }

            return bestHero;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var hero in this.heroes)
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().TrimEnd(); ;
        }
    }
}
