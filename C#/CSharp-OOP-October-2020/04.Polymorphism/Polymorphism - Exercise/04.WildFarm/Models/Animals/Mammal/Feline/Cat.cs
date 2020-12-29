using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals.Mammal.Feline
{
    public class Cat : Feline
    {
        private const double weightMultiplyer = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.PrefferedFood = new List<string>() { "Vegetable", "Meat" };
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
            return "Meow";
        }
    }
}
