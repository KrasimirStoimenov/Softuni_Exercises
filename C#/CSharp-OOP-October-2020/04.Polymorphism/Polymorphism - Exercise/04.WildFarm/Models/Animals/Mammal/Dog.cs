using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals.Mammal
{
    public class Dog : Mammal
    {
        private const double weightMultiplyer = 0.40;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
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
            return "Woof!";
        }
    }
}
