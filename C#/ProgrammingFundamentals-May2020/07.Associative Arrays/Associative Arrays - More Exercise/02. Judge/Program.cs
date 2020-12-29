using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string/*contest*/, Dictionary<string/*user*/, int/*points*/>> contests = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string/*user*/, int/*totalPoints*/> individualStandings = new Dictionary<string, int>();

            Proccessing(contests, individualStandings);

            PrintOutput(contests, individualStandings);



        }

        static void PrintOutput(Dictionary<string, Dictionary<string, int>> contests, Dictionary<string, int> individualStandings)
        {
            PrintContestsOutput(contests);
            PrintIndividualStandings(individualStandings);
        }

        static void PrintIndividualStandings(Dictionary<string, int> individualStandings)
        {
            Console.WriteLine($"Individual standings: ");
            int position = 1;
            foreach (var kvp in individualStandings.OrderByDescending(x => x.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{position}. {kvp.Key} -> {kvp.Value}");
                position++;
            }
        }

        static void PrintContestsOutput(Dictionary<string, Dictionary<string, int>> contests)
        {
            foreach (var cvp in contests)
            {
                Console.WriteLine($"{cvp.Key}: {cvp.Value.Count()} participants");
                int count = 1;
                foreach (var kvp in cvp.Value.OrderByDescending(x => x.Value).ThenBy(n => n.Key))
                {
                    Console.WriteLine($"{count}. {kvp.Key} <::> {kvp.Value}");
                    count++;
                }
            }
        }

        static void Proccessing(Dictionary<string, Dictionary<string, int>> contests, Dictionary<string, int> individualStandings)
        {
            string command;
            while ((command = Console.ReadLine()) != "no more time")
            {
                //{username} -> {contest} -> {points}

                string[] cmdArgs = command.Split(" -> ");
                AddContestsAndParticipants(contests, cmdArgs);
                //TODO  check if user increase points -- dont go in individualstandings

            }
            FillIndividualStandingsDictionary(individualStandings, contests);
        }

        static void FillIndividualStandingsDictionary(Dictionary<string, int> individualStandings, Dictionary<string, Dictionary<string, int>> contests)
        {
            foreach (var kvp in contests)
            {
                foreach (var uvp in kvp.Value)
                {
                    if (individualStandings.ContainsKey(uvp.Key))
                    {
                        individualStandings[uvp.Key] += uvp.Value;
                    }
                    else
                    {
                        individualStandings.Add(uvp.Key, uvp.Value);
                    }
                }

            }

        }

        static void AddContestsAndParticipants(Dictionary<string, Dictionary<string, int>> contests, string[] cmdArgs)
        {
            string userName = cmdArgs[0];
            string currentContest = cmdArgs[1];
            int points = int.Parse(cmdArgs[2]);

            if (!contests.ContainsKey(currentContest))
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                dict.Add(userName, points);
                contests.Add(currentContest, dict);
            }
            else
            {
                if (contests[currentContest].ContainsKey(userName))
                {
                    if (contests[currentContest][userName] < points)
                    {
                        contests[currentContest][userName] = points;
                    }
                }
                else
                {
                    contests[currentContest].Add(userName, points);
                }
            }
        }
    }
}
