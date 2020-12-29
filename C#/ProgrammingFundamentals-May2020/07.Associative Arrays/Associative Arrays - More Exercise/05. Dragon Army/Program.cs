using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Dragon_Army
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string/*type*/, SortedDictionary<string/*dragonName*/, Dragon>> dragonArmy = new Dictionary<string, SortedDictionary<string, Dragon>>();

            Proccessing(dragonArmy);
            PrintOutput(dragonArmy);

        }

        static void PrintOutput(Dictionary<string, SortedDictionary<string, Dragon>> dragonArmy)
        {
            foreach (var dragonType in dragonArmy)
            {
                double averageDamage = 0;
                double averageHealth = 0;
                double averageArmor = 0;

                foreach (var dragon in dragonType.Value)
                {
                    averageDamage += dragon.Value.Damage;
                    averageHealth += dragon.Value.Health;
                    averageArmor += dragon.Value.Armor;
                }

                averageDamage /= dragonType.Value.Count;
                averageHealth /= dragonType.Value.Count;
                averageArmor /= dragonType.Value.Count;

                Console.WriteLine($"{dragonType.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                foreach (var dragon in dragonType.Value)
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value.Damage}, health: {dragon.Value.Health}, armor: {dragon.Value.Armor}");
                }
            }
        }

        static void Proccessing(Dictionary<string, SortedDictionary<string, Dragon>> dragonArmy)
        {
            int dragonsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < dragonsCount; i++)
            {
                //{type} {name} {damage} {health} {armor}
                string[] cmdArgs = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                string type = cmdArgs[0];
                string name = cmdArgs[1];

                string damage = cmdArgs[2];
                int dragonDamage = GetDragonDamage(damage);

                string health = cmdArgs[3];
                int dragonHealth = GetDragonHealth(health);

                string armor = cmdArgs[4];
                int dragonArmor = GetDragonArmor(armor);

                if (!dragonArmy.ContainsKey(type))
                {
                    Dragon dragon = new Dragon(dragonDamage, dragonHealth, dragonArmor);
                    SortedDictionary<string, Dragon> temp = new SortedDictionary<string, Dragon>();
                    temp.Add(name, dragon);
                    dragonArmy.Add(type, temp);
                }
                else
                {
                    if (dragonArmy[type].ContainsKey(name))
                    {
                        dragonArmy[type][name].Damage = dragonDamage;
                        dragonArmy[type][name].Health = dragonHealth;
                        dragonArmy[type][name].Armor = dragonArmor;
                    }
                    else
                    {
                        Dragon dragon = new Dragon(dragonDamage, dragonHealth, dragonArmor);
                        dragonArmy[type].Add(name, dragon);
                    }
                }



            }
        }

        static int GetDragonArmor(string armor)
        {
            int dragonArmor = 0;
            if (armor == "null")
            {
                dragonArmor = 10;
            }
            else
            {
                dragonArmor = int.Parse(armor);
            }

            return dragonArmor;
        }

        static int GetDragonHealth(string health)
        {
            int dragonHealth = 0;
            if (health == "null")
            {
                dragonHealth = 250;
            }
            else
            {
                dragonHealth = int.Parse(health);
            }

            return dragonHealth;
        }

        static int GetDragonDamage(string damage)
        {
            int dragonDamage = 0;
            if (damage == "null")
            {
                dragonDamage = 45;
            }
            else
            {
                dragonDamage = int.Parse(damage);
            }

            return dragonDamage;
        }
    }
    //class Dragon
    //{
    //    public int Damage { get; set; }

    //    public int Health { get; set; }

    //    public int Armor { get; set; }

    //    public Dragon(int damage, int health, int armor)
    //    {
    //        this.Damage = damage;
    //        this.Health = health;
    //        this.Armor = armor;
    //    }
    //}

}
