using System;
using System.Collections.Generic;

using _04.BorderControl.Interface;
using _04.BorderControl.Models;

namespace _04.BorderControl.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<IControlable> controlUnits;

        public Engine()
        {
            this.controlUnits = new List<IControlable>();
        }

        public void Run()
        {
            Processing();
            string fakeIdsLastNumbers = Console.ReadLine();

            DetainedFakeIds(fakeIdsLastNumbers, controlUnits);
        }

        private void DetainedFakeIds(string fakeIdsLastNumbers, ICollection<IControlable> controlUnits)
        {
            foreach (var unit in controlUnits)
            {
                if (unit.Id.EndsWith(fakeIdsLastNumbers))
                {
                    Console.WriteLine(unit.Id);
                }
            }
        }

        private void Processing()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" ");
                string name = cmdArgs[0];

                IControlable controlUnit;
                if (cmdArgs.Length == 3)
                {
                    int age = int.Parse(cmdArgs[1]);
                    string id = cmdArgs[2];

                    controlUnit = new Citizen(name, age, id);
                }
                else
                {
                    string id = cmdArgs[1];
                    controlUnit = new Robot(name, id);
                }

                controlUnits.Add(controlUnit);
            }
        }
    }
}
