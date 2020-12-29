using System;
using System.Collections.Generic;
using System.Text;

namespace Battle_Manager
{
    class Person
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Energy { get; set; }

        public Person(string name, int health, int energy)
        {
            this.Name = name;
            this.Health = health;
            this.Energy = energy;
        }
        public override string ToString()
        {
            return $"{Name} - {Health} - {Energy}";
        }
    }
}
