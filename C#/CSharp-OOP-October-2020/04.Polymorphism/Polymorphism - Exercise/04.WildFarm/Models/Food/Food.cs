using _04.WildFarm.Models.Food.Contracts;

namespace _04.WildFarm.Models.Food
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; }
    }
}
