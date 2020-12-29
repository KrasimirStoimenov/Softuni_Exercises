using System;
using System.Linq;

namespace _05._Pizza_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ingredients = Console.ReadLine().Split();
            int lengthOfIngredientsName = int.Parse(Console.ReadLine());

            int ingredientsCount = 0;
            for (int i = 0; i < ingredients.Length; i++)
            {
                string currentIngredient = ingredients[i];
                if (currentIngredient.Length == lengthOfIngredientsName)
                {
                    ingredientsCount++;
                    Console.WriteLine($"Adding {currentIngredient}.");
                }
                else
                {
                    ingredients[i] = null;
                }
                if (ingredientsCount == 10)
                {
                    for (int j = 10; j < ingredients.Length; j++)
                    {
                        ingredients[j] = null;
                    }
                    break;
                }
            }

            var validIngredients = ingredients.Where(x => x != null).ToArray();
            Console.WriteLine($"Made pizza with total of {ingredientsCount} ingredients.");
            Console.WriteLine($"The ingredients are: {string.Join(", ", validIngredients)}.");
        }
    }
}
