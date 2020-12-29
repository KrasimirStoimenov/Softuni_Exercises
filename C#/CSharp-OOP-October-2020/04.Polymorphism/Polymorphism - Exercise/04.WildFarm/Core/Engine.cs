using System;
using System.Collections.Generic;

using _04.WildFarm.IO;
using _04.WildFarm.Factories;
using _04.WildFarm.Models.Food;
using _04.WildFarm.Models.Animals;
using _04.WildFarm.Core.Contracts;

namespace _04.WildFarm.Core
{
    public class Engine : IEngine
    {
        private ICollection<Animal> animals;
        private ConsoleWriter writer;
        private ConsoleReader reader;
        private FoodFactory foodFactory;
        private AnimalFactory animalFactory;
        public Engine()
        {
            this.animals = new List<Animal>();
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.foodFactory = new FoodFactory();
            this.animalFactory = new AnimalFactory();
        }

        public void Run()
        {
            Processing();
            PrintOutput(animals);
        }

        private void PrintOutput(ICollection<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private void Processing()
        {
            string animal;
            while ((animal = reader.ReadLine()) != "End")
            {
                string[] animalArgs = animal.Split(" ");
                string[] foodArgs = reader.ReadLine().Split(" ");
                Animal currentAnimal = animalFactory.ProduceAnimal(animalArgs);
                Food currentFood = foodFactory.ProduceFood(foodArgs);

                animals.Add(currentAnimal);

                writer.WriteLine(currentAnimal.ProduceSound());
                try
                {
                    currentAnimal.Eat(currentFood.GetType().Name, currentFood.Quantity);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine(ae.Message);
                }

            }
        }
    }
}
