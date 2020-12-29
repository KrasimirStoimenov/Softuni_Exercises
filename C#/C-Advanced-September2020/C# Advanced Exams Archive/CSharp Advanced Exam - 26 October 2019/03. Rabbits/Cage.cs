using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> rabbits;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.rabbits = new List<Rabbit>();
        }

        public int Count { get => this.rabbits.Count; }
        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public void Add(Rabbit rabbit)
        {
            if (this.Capacity > this.rabbits.Count)
            {
                this.rabbits.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            Rabbit rabbit = rabbits.FirstOrDefault(x => x.Name == name);
            if (rabbit == null)
            {
                return false;
            }
            return true;
        }

        public void RemoveSpecies(string species)
        {
            rabbits.RemoveAll(x => x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = rabbits.FirstOrDefault(x => x.Name == name);
            rabbit.Available = false;

            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] rabbitsSpecies = rabbits.Where(x => x.Species == species).ToArray();
            foreach (var rabbit in rabbitsSpecies)
            {
                rabbit.Available = false;
            }
            return rabbitsSpecies;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var rabbit in rabbits.Where(x => x.Available == true)) 
            {
                sb.AppendLine($"{rabbit}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
