using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] demons = Console.ReadLine()
                .Split(",")
                .ToArray();
            List<Demon> demonList = new List<Demon>();

            for (int i = 0; i < demons.Length; i++)
            {
                demons[i] = demons[i].Trim(' ');


                double demonHealth = GetDemonHealth(demons[i]);
                decimal demonDamage = GetDemonDamage(demons[i]);
                Demon demon = new Demon(demons[i], demonHealth, demonDamage);
                demonList.Add(demon);
            }

            PrintOutput(demonList);
        }

        static void PrintOutput(List<Demon> demonList)
        {
            foreach (var demon in demonList.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }

        static decimal GetDemonDamage(string currentDemon)
        {
            string demonDamagePattern = @"[\-\+]?[\d]+(?:[\.]*[\d]+|[\d]*)";
            MatchCollection damageCollection = Regex.Matches(currentDemon,demonDamagePattern);
            decimal damage = 0;
            foreach (var number in damageCollection)
            {
                damage += decimal.Parse(number.ToString());
            }

            foreach (char c in currentDemon.Where(c => c == '*' || c == '/'))
            {
                if (c == '*')
                {
                    damage *= 2;
                }
                else
                {
                    damage /= 2;
                }
            }

            return damage;
        }

        static double GetDemonHealth(string currentDemon)
        {
            string healthPattern = @"[^0-9+\-*\/.]";
            double demonHealth = 0;
            MatchCollection letters = Regex.Matches(currentDemon, healthPattern);
            foreach (Match match in letters)
            {
                string current = match.Value;
                char currentChar = char.Parse(current);
                demonHealth += currentChar;
            }

            return demonHealth;
        }
    }

    //class Demon
    //{
    //    public string Name { get; set; }
    //    public double Health { get; set; }
    //    public decimal Damage { get; set; }

    //    public Demon(string name, double health, decimal damage)
    //    {
    //        this.Name = name;
    //        this.Health = health;
    //        this.Damage = damage;
    //    }
    //}



}
