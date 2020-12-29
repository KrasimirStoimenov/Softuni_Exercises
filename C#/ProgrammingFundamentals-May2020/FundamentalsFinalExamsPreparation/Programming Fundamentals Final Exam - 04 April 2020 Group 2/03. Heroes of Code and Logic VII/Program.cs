using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int heroesCount = int.Parse(Console.ReadLine());
            List<Hero> heroes = ReadHeroes(heroesCount);

            Proccessing(heroes);
            PrintSortedOutput(heroes);
        }

        static void PrintSortedOutput(List<Hero> heroes)
        {
            Console.WriteLine(string.Join("", heroes.OrderByDescending(x => x.HitPoints).ThenBy(x => x.HeroName)));
        }

        static void Proccessing(List<Hero> heroes)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" - ").ToArray();

                string spell = cmdArgs[0];
                string heroName = cmdArgs[1];
                Hero currentHero = heroes.Find(x => x.HeroName == heroName);
                switch (spell)
                {
                    case "CastSpell":
                        CastSpellMethod(currentHero, cmdArgs);
                        break;
                    case "TakeDamage":
                        TakeDamageMethod(currentHero, cmdArgs, heroes);
                        break;
                    case "Recharge":
                        RechargeMethod(currentHero, int.Parse(cmdArgs[2]));
                        break;
                    case "Heal":
                        HealMethod(currentHero, int.Parse(cmdArgs[2]));
                        break;
                }
            }
        }

        static void HealMethod(Hero currentHero, int healthAmount)
        {
            int currentHealthAmount = healthAmount + currentHero.HitPoints;
            int healthRecharged = 0;
            if (currentHealthAmount > 100)
            {
                healthRecharged = 100 - currentHero.HitPoints;
                currentHero.HitPoints = 100;
            }
            else
            {
                currentHero.HitPoints += healthAmount;
                healthRecharged = healthAmount;
            }
            Console.WriteLine($"{currentHero.HeroName} healed for {healthRecharged} HP!");
        }

        static void RechargeMethod(Hero currentHero, int amountMP)
        {
            int currentAmount = amountMP + currentHero.ManaPoints;
            int manaRecharged = 0;
            if (currentAmount > 200)
            {
                manaRecharged = 200 - currentHero.ManaPoints;
                currentHero.ManaPoints = 200;
            }
            else
            {
                currentHero.ManaPoints += amountMP;
                manaRecharged = amountMP;
            }

            Console.WriteLine($"{currentHero.HeroName} recharged for {manaRecharged} MP!");
        }

        static void TakeDamageMethod(Hero currentHero, string[] cmdArgs, List<Hero> heroes)
        {
            int damage = int.Parse(cmdArgs[2]);
            string attacker = cmdArgs[3];

            if (currentHero.HitPoints > damage)
            {
                currentHero.HitPoints -= damage;
                Console.WriteLine($"{currentHero.HeroName} was hit for {damage} HP by {attacker} and now has {currentHero.HitPoints} HP left!");
            }
            else
            {
                Console.WriteLine($"{currentHero.HeroName} has been killed by {attacker}!");
                heroes.Remove(currentHero);
            }
        }

        static void CastSpellMethod(Hero currentHero, string[] cmdArgs)
        {
            int mpNeededForSpell = int.Parse(cmdArgs[2]);
            string spellName = cmdArgs[3];

            if (currentHero.ManaPoints >= mpNeededForSpell)
            {
                currentHero.ManaPoints -= mpNeededForSpell;
                Console.WriteLine($"{currentHero.HeroName} has successfully cast {spellName} and now has {currentHero.ManaPoints} MP!");
            }
            else
            {
                Console.WriteLine($"{currentHero.HeroName} does not have enough MP to cast {spellName}!");
            }
        }

        static List<Hero> ReadHeroes(int heroesCount)
        {
            List<Hero> heroes = new List<Hero>();
            for (int i = 0; i < heroesCount; i++)
            {
                string[] args = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                string heroName = args[0];
                int hp = int.Parse(args[1]);
                int mp = int.Parse(args[2]);

                Hero hero = new Hero(heroName, hp, mp);
                heroes.Add(hero);                           // To check if read the same name twice;
            }

            return heroes;
        }
    }
    //class Hero
    //{
    //    public string HeroName { get; set; }
    //    public int HitPoints { get; set; }
    //    public int ManaPoints { get; set; }

    //    public Hero(string name, int hp, int mp)
    //    {
    //        this.HeroName = name;
    //        this.HitPoints = hp;
    //        this.ManaPoints = mp;
    //    }

    //    public override string ToString()
    //    {
    //        StringBuilder overrided = new StringBuilder();
    //        overrided.AppendLine(HeroName);
    //        overrided.AppendLine($"  HP: {HitPoints}");
    //        overrided.AppendLine($"  MP: {ManaPoints}");
    //        return overrided.ToString();
    //    }
    //}

}
