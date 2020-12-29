using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Tire[] tires = new Tire[4]
            {
                new Tire(1,2.5),
                new Tire(1,2.1),
                new Tire(2,0.5),
                new Tire(2,2.3)
            };

            Engine engine = new Engine(560, 6300);

            Car car = new Car("BMW", "E90", 2008, 60, 6, engine, tires);

            Console.WriteLine(car.WhoAmI());
        }
    }
}
