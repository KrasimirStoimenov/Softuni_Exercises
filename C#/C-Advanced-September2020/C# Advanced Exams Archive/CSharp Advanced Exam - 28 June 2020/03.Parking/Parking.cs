using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> cars;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.cars = new List<Car>();
        }
        public int Count => this.cars.Count;
        public string Type { get; set; }

        public int Capacity { get; set; }

        public void Add(Car car)
        {
            if (this.cars.Count < this.Capacity)
            {
                cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
            => this.cars.Remove(cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model));

        public Car GetLatestCar()
            => this.cars.OrderByDescending(x => x.Year).FirstOrDefault();

        public Car GetCar(string manufacturer, string model)
            => this.cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in this.cars)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
