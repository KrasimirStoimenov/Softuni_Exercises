using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        public Pizza()
        {
            this.toppings = new List<Topping>();
        }
        public Pizza(string name, Dough dough)
            : this()
        {
            this.Name = name;
            this.dough = dough;
        }
        public int ToppingCount => this.toppings.Count;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public double TotalCalories()
        {
            double doughCalories = this.dough.TotalCalories();
            double toppingsCalories = this.toppings.Sum(x => x.TotalCalories());

            double totalPizzaCalories = doughCalories + toppingsCalories;
            return totalPizzaCalories;
        }
        public void AddTopping(Topping topping)
        {
            if (this.ToppingCount < 10)
            {
                toppings.Add(topping);
            }
            else
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories():F2} Calories.";
        }
    }
}
