using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "BMW";
            car.Model = "E90";
            car.Year = 2008;
            car.FuelQuantity = 60;
            car.FuelConsumption = 6;
            car.Drive(933);
            Console.WriteLine(car.WhoAmI());

        }
    }
}
