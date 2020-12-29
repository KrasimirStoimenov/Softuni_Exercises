using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }
        public string Name { get; private set; }

        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; private set; }

        public void AddPokemon(Pokemon pokemon)
        {
            this.Pokemons.Add(pokemon);
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
        }
    }
}
