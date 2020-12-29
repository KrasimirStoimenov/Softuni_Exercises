using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Pokemon
    {
        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }
        public string Name { get; private set; }

        public string Element { get; private set; }

        public int Health { get; set; }

    }
}
