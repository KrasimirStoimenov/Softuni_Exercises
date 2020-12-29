using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string/*hatColor*/, Dictionary<string/*dwarfName*/, int/*physics*/>> dwarves = new Dictionary<string, Dictionary<string, int>>();

            Proccessing(dwarves);
            PrintOutput(dwarves);
        }

        static void PrintOutput(Dictionary<string, Dictionary<string, int>> dwarves)
        {
            Dictionary<string, int> sortedDwarves = new Dictionary<string, int>();
            foreach (var hatColor in dwarves.OrderByDescending(x => x.Value.Count()))
            {
                foreach (var dwarf in hatColor.Value)
                {
                    sortedDwarves.Add($"({hatColor.Key}) {dwarf.Key} <-> ", dwarf.Value);
                }
            }
            foreach (var dwarf in sortedDwarves.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{dwarf.Key}{dwarf.Value}");
            }
        }

        static void Proccessing(Dictionary<string, Dictionary<string, int>> dwarves)
        {
            string command;
            while ((command = Console.ReadLine()) != "Once upon a time")
            {
                //{dwarfName} <:> {dwarfHatColor} <:> {dwarfPhysics}
                string[] cmdArgs = command.Split(" <:> ").ToArray();
                string dwarfName = cmdArgs[0];
                string hatColor = cmdArgs[1];
                int physics = int.Parse(cmdArgs[2]);

                if (dwarves.ContainsKey(hatColor))
                {
                    if (dwarves[hatColor].ContainsKey(dwarfName))
                    {
                        if (dwarves[hatColor][dwarfName] < physics)
                        {
                            dwarves[hatColor][dwarfName] = physics;
                        }
                    }
                    else
                    {
                        dwarves[hatColor].Add(dwarfName, physics);
                    }
                }
                else
                {
                    Dictionary<string, int> temp = new Dictionary<string, int>();
                    temp.Add(dwarfName, physics);
                    dwarves.Add(hatColor, temp);
                }

            }
        }
    }
}
