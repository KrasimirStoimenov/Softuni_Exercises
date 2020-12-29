using _04.WildFarm.Models.Food;
using _04.WildFarm.Factories.Contracts;

namespace _04.WildFarm.Factories
{
    public class FoodFactory : IFoodProductable
    {
        public Food ProduceFood(string[] args)
        {
            Food food = null;
            string foodType = args[0];
            int quantity = int.Parse(args[1]);
            if (foodType == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (foodType == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(quantity);
            }

            return food;
        }
    }
}
