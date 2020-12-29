using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.Animals.Bird;
using _04.WildFarm.Factories.Contracts;
using _04.WildFarm.Models.Animals.Mammal;
using _04.WildFarm.Models.Animals.Mammal.Feline;

namespace _04.WildFarm.Factories
{
    public class AnimalFactory : IAnimalProductable
    {
        public Animal ProduceAnimal(string[] args)
        {
            Animal animal = null;
            string type = args[0];
            string name = args[1];
            double weight = double.Parse(args[2]);
            if (type == "Owl" || type == "Hen")
            {
                double wingSize = double.Parse(args[3]);
                if (type == "Owl")
                {
                    animal = new Owl(name, weight, wingSize);
                }
                else if (type == "Hen")
                {
                    animal = new Hen(name, weight, wingSize);
                }
            }
            else if (type == "Cat" || type == "Tiger")
            {
                string livingRegion = args[3];
                string breed = args[4];
                if (type == "Cat")
                {
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else if (type == "Tiger")
                {
                    animal = new Tiger(name, weight, livingRegion, breed);
                }
            }
            else if (type == "Dog" || type == "Mouse")
            {
                string livingRegion = args[3];
                if (type == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else if (type == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
            }

            return animal;
        }
    }
}
