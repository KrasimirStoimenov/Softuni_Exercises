using System;
using System.Collections.Generic;

using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Garages.Contracts;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int cappacity = 10;
        private Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            string robotName = robot.Name;

            if (this.robots.Count == cappacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robotName));
            }

            this.robots.Add(robotName, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            this.robots[robotName].IsBought = true;
            this.robots[robotName].Owner = ownerName;
            this.robots.Remove(robotName);
        }
    }
}
