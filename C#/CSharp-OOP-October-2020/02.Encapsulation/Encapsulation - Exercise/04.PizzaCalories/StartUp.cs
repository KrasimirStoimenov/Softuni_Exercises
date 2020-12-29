using System;
using System.Linq;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {

                string[] pizzaName = Console.ReadLine().Split().ToArray();
                string name = pizzaName[1];
                Dough dough = GetDough();
                Pizza pizza = new Pizza(name, dough);

                string topping;
                while ((topping = Console.ReadLine()) != "END")
                {
                    Topping currentTopping = GetTopping(topping);

                    pizza.AddTopping(currentTopping);

                }

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static Topping GetTopping(string topping)
        {
            string[] toppingArgs = topping
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string toppingName = toppingArgs[1];
            int toppingWeight = int.Parse(toppingArgs[2]);

            Topping currentTopping = new Topping(toppingName, toppingWeight);
            return currentTopping;
        }

        private static Dough GetDough()
        {
            string[] doughArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string flourType = doughArgs[1];
            string bakingTechnique = doughArgs[2];
            int weight = int.Parse(doughArgs[3]);
            Dough dough = new Dough(flourType, bakingTechnique, weight);
            return dough;
        }
    }
}
