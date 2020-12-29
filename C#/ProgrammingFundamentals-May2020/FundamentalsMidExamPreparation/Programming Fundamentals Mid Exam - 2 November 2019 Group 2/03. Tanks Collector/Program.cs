using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Tanks_Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tanksOwned = Console.ReadLine()
                .Split(", ")
                .ToList();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(", ");
                switch (cmdArgs[0])
                {
                    case "Add":
                        string tankName = cmdArgs[1];
                        if (tanksOwned.Contains(tankName))
                        {
                            Console.WriteLine("Tank is already bought");
                        }
                        else
                        {
                            tanksOwned.Add(tankName);
                            Console.WriteLine("Tank successfully bought");
                        }
                        break;
                    case "Remove":
                        string removeTankName = cmdArgs[1];
                        if (tanksOwned.Contains(removeTankName))
                        {
                            tanksOwned.Remove(removeTankName);
                            Console.WriteLine("Tank successfully sold");
                        }
                        else
                        {
                            Console.WriteLine("Tank not found");
                        }
                        break;
                    case "Remove At":
                        int index = int.Parse(cmdArgs[1]);
                        if (index < 0 || index >= tanksOwned.Count)
                        {
                            Console.WriteLine("Index out of range");
                        }
                        else
                        {
                            tanksOwned.RemoveAt(index);
                            Console.WriteLine("Tank successfully sold");
                        }
                        break;
                    case "Insert":
                        int insertIndex = int.Parse(cmdArgs[1]);
                        string insertTankName = cmdArgs[2];
                        if (insertIndex < 0 || insertIndex >= tanksOwned.Count)
                        {
                            Console.WriteLine("Index out of range");
                        }
                        else if (tanksOwned.Contains(insertTankName))
                        {
                            Console.WriteLine("Tank is already bought");
                        }
                        else
                        {
                            tanksOwned.Insert(insertIndex, insertTankName);
                            Console.WriteLine("Tank successfully bought");
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", tanksOwned));
        }
    }
}
