using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const int DEFAULT_TOPPING_CALORIES_PER_GRAM = 2;
        private const int TOPPING_MIN_WEIGHT = 1;
        private const int TOPPING_MAX_WEIGHT = 50;
        private string toppingName;
        private int weight;

        public Topping(string toppingName, int weight)
        {
            this.ToppingName = toppingName;
            this.Weight = weight;
        }
        public string ToppingName
        {
            get
            {
                return this.toppingName;
            }
            set
            {
                if (!Toppings.IsValidTopping(value))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                this.toppingName = value;
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < TOPPING_MIN_WEIGHT || value > TOPPING_MAX_WEIGHT)
                {
                    throw new Exception($"{this.ToppingName} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public double TotalCalories()
        {
            double toppingModifier = Toppings.GetModifier(this.ToppingName);
            double totalCalories = DEFAULT_TOPPING_CALORIES_PER_GRAM * this.Weight * toppingModifier;

            return totalCalories;
        }



        private static class Toppings
        {
            private static Dictionary<string, double> toppings = new Dictionary<string, double>()
        {
            { "meat",1.2 },
            { "veggies",0.8 },
            { "cheese",1.1 },
            { "sauce",0.9 }
        };

            public static bool IsValidTopping(string type)
            {
                if (toppings.ContainsKey(type.ToLower()))
                {
                    return true;
                }
                return false;
            }

            public static double GetModifier(string type)
            {
                return toppings[type.ToLower()];
            }
        }
    }
}

