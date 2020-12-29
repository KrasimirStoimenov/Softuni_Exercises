using _04.WildFarm.Models.Food;

namespace _04.WildFarm.Factories.Contracts
{
    public interface IFoodProductable
    {
        Food ProduceFood(string[] args);
    }
}
