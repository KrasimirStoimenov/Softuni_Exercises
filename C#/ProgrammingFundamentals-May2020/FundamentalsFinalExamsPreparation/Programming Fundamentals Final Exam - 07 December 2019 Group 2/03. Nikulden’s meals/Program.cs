using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Nikulden_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string/*user*/, List<string>/*meals*/> guestMeals = new Dictionary<string, List<string>>();
            int unlikedMeals = 0;
            Proccessing(guestMeals, ref unlikedMeals);
            PrintOutput(guestMeals, unlikedMeals);

        }

        static void PrintOutput(Dictionary<string, List<string>> guestMeals, int unlikedMeals)
        {
            foreach (var guest in guestMeals.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{guest.Key}: {string.Join(", ", guest.Value)}");
            }

            Console.WriteLine($"Unliked meals: {unlikedMeals}");
        }

        static void Proccessing(Dictionary<string, List<string>> guestMeals, ref int unlikedMeals)
        {
            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command.Split("-");
                string action = cmdArgs[0];
                string guest = cmdArgs[1];
                string meal = cmdArgs[2];

                if (action == "Like")
                {
                    if (guestMeals.ContainsKey(guest))
                    {
                        if (!guestMeals[guest].Contains(meal))
                        {
                            guestMeals[guest].Add(meal);
                        }
                    }
                    else
                    {
                        guestMeals.Add(guest, new List<string>() { meal });
                    }
                }
                else
                {
                    if (guestMeals.ContainsKey(guest))
                    {
                        if (!guestMeals[guest].Contains(meal))
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                        else
                        {
                            guestMeals[guest].Remove(meal);
                            unlikedMeals++;
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                }
            }
        }
    }
}
