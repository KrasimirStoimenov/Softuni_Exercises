using System;
using System.Linq;
using System.Collections.Generic;

using RobotService.Core.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Garages;
using RobotService.Models.Procedures;
using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures.Contracts;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private Dictionary<string, IProcedure> procedures;
        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<string, IProcedure>()
            {
                {"Chip", new Chip() },
                {"Charge", new Charge() },
                {"Polish", new Polish() },
                {"Rest", new Rest() },
                {"TechCheck", new TechCheck() },
                {"Work", new Work() }
            };
        }
        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotIfExist(robotName);

            this.procedures["Charge"].DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotIfExist(robotName);

            this.procedures["Chip"].DoService(robot, procedureTime);


            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string History(string procedureType)
        {
            var procedure = this.procedures.FirstOrDefault(x => x.Key == procedureType);

            return procedure.Value.History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;
            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            //var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == robotType);
            //var ctorParams = new object[] { name, energy, happiness, procedureTime };
            //IRobot robot = Activator.CreateInstance(type, ctorParams) as IRobot;

            garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotIfExist(robotName);

            this.procedures["Polish"].DoService(robot, procedureTime);


            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotIfExist(robotName);

            this.procedures["Rest"].DoService(robot, procedureTime);


            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = GetRobotIfExist(robotName);
            this.garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotIfExist(robotName);

            this.procedures["TechCheck"].DoService(robot, procedureTime);


            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotIfExist(robotName);

            this.procedures["Work"].DoService(robot, procedureTime);


            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        private IRobot GetRobotIfExist(string robotName)
        {
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            if (robot == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            return robot;
        }
    }
}
