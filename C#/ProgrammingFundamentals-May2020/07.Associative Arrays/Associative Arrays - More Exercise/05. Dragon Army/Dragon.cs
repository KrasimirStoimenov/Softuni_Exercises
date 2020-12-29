using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Dragon_Army
{
    class Dragon
    {
        public int Damage { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }

        public Dragon(int damage, int health, int armor)
        {
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }
    }
}
