using System;
using System.Text;
using System.Collections.Generic;

using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Procedures.Contracts;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            this.robots = new List<IRobot>();
        }
        protected ICollection<IRobot> robots { get; }
        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }

            robot.ProcedureTime -= procedureTime;
        }

        public string History()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            foreach (var robot in this.robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
