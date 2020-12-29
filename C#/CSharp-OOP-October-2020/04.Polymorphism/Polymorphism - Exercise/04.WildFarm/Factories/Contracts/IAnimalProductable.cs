using _04.WildFarm.Models.Animals;

namespace _04.WildFarm.Factories.Contracts
{
    public interface IAnimalProductable
    {
        Animal ProduceAnimal(string[] args);
    }
}
