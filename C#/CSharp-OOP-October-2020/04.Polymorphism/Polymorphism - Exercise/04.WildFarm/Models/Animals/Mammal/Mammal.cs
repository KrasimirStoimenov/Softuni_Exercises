using _04.WildFarm.Models.Animals.Contracts;

namespace _04.WildFarm.Models.Animals.Mammal
{
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
