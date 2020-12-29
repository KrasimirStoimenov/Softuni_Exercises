using System;
using System.Linq;
using System.Collections.Generic;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> reservationList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> filters = new List<string>();
            ReadFilters(filters);
            Predicate<string> predicate = null;
            foreach (var filter in filters)
            {
                string[] filterArgs = filter.Split(";").ToArray();
                string funcArg = filterArgs[0];
                string argument = filterArgs[1];

                switch (funcArg)
                {
                    case "Starts with":
                        predicate = x => x.StartsWith(argument);
                        break;
                    case "Ends with":
                        predicate = x => x.EndsWith(argument);
                        break;
                    case "Length":
                        predicate = x => x.Length == int.Parse(argument);
                        break;
                    case "Contains":
                        predicate = x => x.Contains(argument);
                        break;
                }

                reservationList.RemoveAll(predicate);
            }

            Console.WriteLine(string.Join(" ", reservationList));

        }

        private static void ReadFilters(List<string> filters)
        {
            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] cmdArgs = command.Split(";").ToArray();
                string action = cmdArgs[0];
                string filter = $"{cmdArgs[1]};{cmdArgs[2]}";
                if (action == "Add filter")
                {
                    filters.Add(filter);
                }
                else if (action == "Remove filter")
                {
                    filters.Remove(filter);
                }
            }
        }
    }
}
