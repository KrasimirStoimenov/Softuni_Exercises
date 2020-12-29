using System.Collections.Generic;

using _04.WildFarm.Models.Animals.Contracts;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract ICollection<string> PrefferedFood { get; }
        public abstract void Eat(string type, int quantity);

        public abstract string ProduceSound();
    }
}
