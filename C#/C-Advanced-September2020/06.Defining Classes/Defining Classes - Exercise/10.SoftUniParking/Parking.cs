using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public int Count => this.cars.Count;

        public string AddCar(Car Car)
        {
            if (this.cars.Any(x=>x.RegistrationNumber==Car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (this.cars.Count >= this.capacity)
            {
                return "Parking is full!";
            }

            this.cars.Add(Car);
            return $"Successfully added new car {Car.Make} {Car.RegistrationNumber}";
        }

        public string RemoveCar(string RegistrationNumber)
        {
            Car car = this.cars.Find(x => x.RegistrationNumber == RegistrationNumber);
            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                this.cars.Remove(car);
                return $"Successfully removed {car.RegistrationNumber}";
            }
        }

        public Car GetCar(string RegistrationNumber)
        {
            return this.cars.FirstOrDefault(x => x.RegistrationNumber == RegistrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var reg in RegistrationNumbers)
            {
                this.cars.RemoveAll(x => x.RegistrationNumber == reg);
            }
        }
    }
}

