using System.Collections.Generic;

namespace _04.WildFarm.Models.Animals.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        public ICollection<string> PrefferedFood { get; }
        public void Eat(string type, int quantity);
        public string ProduceSound();
    }
}
