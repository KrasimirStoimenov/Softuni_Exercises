using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vlogger> vloggers = new List<Vlogger>();

            Proccessing(vloggers);
            PrintOutput(vloggers);
        }

        static void PrintOutput(List<Vlogger> vloggers)
        {
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            var orderedVloggersByFollowers = vloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Followings).ToList();
            PrintMostFamousVlogger(orderedVloggersByFollowers);
            orderedVloggersByFollowers.RemoveAt(0);
            int counter = 1;
            foreach (var vlogger in orderedVloggersByFollowers)
            {
                counter++;
                Console.WriteLine($"{counter}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Followings} following");
            }
        }

        static void PrintMostFamousVlogger(List<Vlogger> orderedVloggersByFollowers)
        {
            Vlogger mostFamousVlogger = orderedVloggersByFollowers[0];
            Console.WriteLine($"1. {mostFamousVlogger.Name} : {mostFamousVlogger.Followers.Count} followers, {mostFamousVlogger.Followings} following");
            foreach (var follower in mostFamousVlogger.Followers.OrderBy(x => x))
            {
                Console.WriteLine($"*  {follower}");
            }
        }

        static void Proccessing(List<Vlogger> vloggers)
        {
            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = command.Split(" ").ToArray();
                string firstVloggerName = cmdArgs[0];
                string action = cmdArgs[1];
                if (action == "joined")
                {
                    if (!VloggerExistValidator(vloggers, firstVloggerName))
                    {
                        Vlogger vlogger = new Vlogger(firstVloggerName);
                        vloggers.Add(vlogger);
                    }
                }
                else if (action == "followed")
                {
                    string secondVloggerName = cmdArgs[2];
                    if (VloggerExistValidator(vloggers, firstVloggerName)
                        && VloggerExistValidator(vloggers, secondVloggerName))
                    {
                        if (firstVloggerName != secondVloggerName)
                        {
                            Vlogger firstVlogger = vloggers.Find(x => x.Name == firstVloggerName);
                            Vlogger secondVlogger = vloggers.Find(x => x.Name == secondVloggerName);
                            if (!secondVlogger.Followers.Contains(firstVloggerName))
                            {
                                secondVlogger.Followers.Add(firstVloggerName);
                                firstVlogger.Followings++;
                            }
                        }
                    }
                }
            }
        }
        static bool VloggerExistValidator(List<Vlogger> vloggers, string vloggerName)
        {
            Vlogger currentVlogger = vloggers.Find(x => x.Name == vloggerName);
            if (currentVlogger == null)
            {
                return false;
            }
            return true;
        }
    }
    class Vlogger
    {
        public Vlogger(string name)
        {
            this.Name = name;
            this.Followings = 0;
            this.Followers = new List<string>();
        }
        public string Name { get; private set; }

        public int Followings { get; set; }

        public List<string> Followers { get; private set; }
    }

}
