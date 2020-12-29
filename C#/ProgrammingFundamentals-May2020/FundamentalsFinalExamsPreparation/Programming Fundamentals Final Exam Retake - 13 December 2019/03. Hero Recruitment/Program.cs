using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string/*user*/, List<string>/*spellBook*/> magicians = new Dictionary<string, List<string>>();
            Proccessing(magicians);
            PrintOutput(magicians);
        }

        static void PrintOutput(Dictionary<string, List<string>> magicians)
        {
            Console.WriteLine("Heroes:");
            foreach (var magician in magicians.OrderByDescending(spellCount => spellCount.Value.Count)
                .ThenBy(name => name.Key))
            {
                Console.WriteLine($"== {magician.Key}: {string.Join(", ", magician.Value)}");
            }
        }

        static void Proccessing(Dictionary<string, List<string>> magicians)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" ");
                string action = cmdArgs[0];
                string heroName = cmdArgs[1];
                switch (action)
                {
                    case "Enroll":
                        if (magicians.ContainsKey(heroName))
                        {
                            Console.WriteLine($"{heroName} is already enrolled.");
                        }
                        else
                        {
                            magicians.Add(heroName, new List<string>());
                        }
                        break;
                    case "Learn":
                        string spellName = cmdArgs[2];
                        if (!magicians.ContainsKey(heroName))
                        {
                            Console.WriteLine($"{heroName} doesn't exist.");
                        }
                        else
                        {
                            if (magicians[heroName].Contains(spellName))
                            {
                                Console.WriteLine($"{heroName} has already learnt {spellName}.");
                            }
                            else
                            {
                                magicians[heroName].Add(spellName);
                            }
                        }
                        break;
                    case "Unlearn":
                        string spellNameToUnlearn = cmdArgs[2];
                        if (!magicians.ContainsKey(heroName))
                        {
                            Console.WriteLine($"{heroName} doesn't exist.");
                        }
                        else
                        {
                            if (magicians[heroName].Contains(spellNameToUnlearn))
                            {
                                magicians[heroName].Remove(spellNameToUnlearn);
                            }
                            else
                            {
                                Console.WriteLine($"{heroName} doesn't know {spellNameToUnlearn}.");
                            }
                        }
                        break;

                }
            }
        }
    }
}
