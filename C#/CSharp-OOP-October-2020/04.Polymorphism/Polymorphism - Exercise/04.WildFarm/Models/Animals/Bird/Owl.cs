using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals.Bird
{
    public class Owl : Bird
    {
        private const double weightMultiplyer = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            this.PrefferedFood = new List<string>() { "Meat" };
        }

        public override ICollection<string> PrefferedFood { get; }
        public override void Eat(string type, int quantity)
        {
            if (!this.PrefferedFood.Contains(type))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {type}!");
            }
            this.Weight += quantity * weightMultiplyer;
            this.FoodEaten += quantity;
        }
        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
