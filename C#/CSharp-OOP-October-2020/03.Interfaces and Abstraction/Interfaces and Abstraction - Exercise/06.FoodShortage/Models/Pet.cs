using _06.FoodShortage.Interfaces;

namespace _06.FoodShortage.Models
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Name { get; private set; }
        public string Birthdate { get; private set; }
    }
}
