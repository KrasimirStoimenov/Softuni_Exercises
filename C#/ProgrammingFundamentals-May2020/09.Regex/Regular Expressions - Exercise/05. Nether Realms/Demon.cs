using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Nether_Realms
{
    class Demon
    {
        public string Name { get; set; }
        public long Health { get; set; }
        public double Damage { get; set; }

        public Demon(string name, int health, double damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }
    }
}
