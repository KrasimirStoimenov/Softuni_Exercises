using _04.WildFarm.Models.Animals.Contracts;

namespace _04.WildFarm.Models.Animals.Mammal.Feline
{
    public abstract class Feline : Mammal, IFeline
    {
        protected Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
