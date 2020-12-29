using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public override double OverallPerformance => GetPerformance();

        public override decimal Price => this.Components.Sum(x => x.Price) + this.Peripherals.Sum(x => x.Price) + base.Price;

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var currentComponent = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            if (currentComponent == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            this.components.Remove(currentComponent);
            return currentComponent;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var currentPeripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            if (currentPeripheral == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            this.peripherals.Remove(currentPeripheral);
            return currentPeripheral;
        }
        private double GetPerformance()
        {
            var overallPerformance = base.OverallPerformance;
            if (this.components.Count > 0)
            {
                overallPerformance += this.components.Average(x => x.OverallPerformance);
            }

            return overallPerformance;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.components.Count}):");
            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component}");
            }
            var average = this.peripherals.Count > 0 ? this.peripherals.Average(x => x.OverallPerformance) : 0.00;
            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({average:F2}):");
            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
