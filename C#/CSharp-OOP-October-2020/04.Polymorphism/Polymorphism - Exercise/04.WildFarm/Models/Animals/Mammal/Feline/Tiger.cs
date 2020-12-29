using System;
using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals.Mammal.Feline
{
    public class Tiger : Feline
    {
        private const double weightMultiplyer = 1.00;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
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
            return "ROAR!!!";
        }
    }
}
