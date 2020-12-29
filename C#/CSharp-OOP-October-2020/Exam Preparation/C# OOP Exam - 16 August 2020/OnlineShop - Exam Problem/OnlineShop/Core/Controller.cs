using System;
using System.Linq;
using System.Collections.Generic;

using OnlineShop.Common.Enums;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private ICollection<IComputer> computers;
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer computer = ValidateIfComputerExist(computerId);

            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            if (!Enum.TryParse(componentType, out ComponentType componentCurrentType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            IComponent currentComponent = null;
            switch (componentCurrentType)
            {
                case ComponentType.CentralProcessingUnit:
                    currentComponent = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.Motherboard:
                    currentComponent = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.PowerSupply:
                    currentComponent = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.RandomAccessMemory:
                    currentComponent = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.SolidStateDrive:
                    currentComponent = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case ComponentType.VideoCard:
                    currentComponent = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;

            }

            computer.AddComponent(currentComponent);
            this.components.Add(currentComponent);

            return String.Format(SuccessMessages.AddedComponent, currentComponent.GetType().Name, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            if (!Enum.TryParse(computerType, out ComputerType computerCurrentType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            IComputer currentComputer = null;
            switch (computerCurrentType)
            {
                case ComputerType.DesktopComputer:
                    currentComputer = new DesktopComputer(id, manufacturer, model, price);
                    break;
                case ComputerType.Laptop:
                    currentComputer = new Laptop(id, manufacturer, model, price);
                    break;
            }

            this.computers.Add(currentComputer);
            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = ValidateIfComputerExist(computerId);
            if (this.peripherals.Any(x=>x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            if (!Enum.TryParse(peripheralType, out PeripheralType peripheralCurrentType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            IPeripheral currentPeripheral = null;
            switch (peripheralCurrentType)
            {
                case PeripheralType.Headset:
                    currentPeripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Keyboard:
                    currentPeripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Monitor:
                    currentPeripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case PeripheralType.Mouse:
                    currentPeripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
            }

            computer.AddPeripheral(currentPeripheral);
            this.peripherals.Add(currentPeripheral);

            return String.Format(SuccessMessages.AddedPeripheral, currentPeripheral.GetType().Name, id, computerId);

        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = this.computers.Where(x => x.Price <= budget).OrderByDescending(x => x.OverallPerformance).FirstOrDefault();
            if (computer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = ValidateIfComputerExist(id);

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = ValidateIfComputerExist(id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = ValidateIfComputerExist(computerId);
            IComponent component = this.components.FirstOrDefault(x => x.GetType().Name == componentType);

            computer.RemoveComponent(componentType);
            this.components.Remove(component);

            return String.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = ValidateIfComputerExist(computerId);
            IPeripheral peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheral);

            return String.Format(SuccessMessages.RemovedPeripheral, peripheral.GetType().Name, peripheral.Id);
        }

        private IComputer ValidateIfComputerExist(int computerId)
        {
            IComputer computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computer;
        }
    }
}
