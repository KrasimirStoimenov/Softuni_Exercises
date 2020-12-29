using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>(); //contestName, password
            Dictionary<string/*user*/, Dictionary<string/*contest*/, int/*points*/>> participants = new Dictionary<string, Dictionary<string, int>>();

            AddingContests(contests);
            ParticipateUsersInContest(contests, participants);

            int bestCandidatePoints = 0;
            string bestCandidate = GetBestCandidate(participants, ref bestCandidatePoints);

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidatePoints} points.");
            PrintOutput(participants);


        }

        static void PrintOutput(Dictionary<string, Dictionary<string, int>> participants)
        {
            Console.WriteLine("Ranking: ");

            foreach (var kvp in participants.OrderBy(n => n.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (var uvp in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {uvp.Key} -> {uvp.Value}");
                }
            }
        }

        static string GetBestCandidate(Dictionary<string, Dictionary<string, int>> participants, ref int bestPoints)
        {
            string bestCandidate = string.Empty;
            foreach (var kvp in participants)
            {
                int currentPoints = 0;
                foreach (var pvp in kvp.Value)
                {
                    currentPoints += pvp.Value;
                }
                if (currentPoints > bestPoints)
                {
                    bestCandidate = kvp.Key;
                    bestPoints = currentPoints;
                }
            }

            return bestCandidate;
        }

        static void ParticipateUsersInContest(Dictionary<string, string> contests, Dictionary<string, Dictionary<string, int>> participants)
        {
            string command;
            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] cmdArgs = command.Split("=>");
                string contest = cmdArgs[0];
                string currentPassword = cmdArgs[1];
                string username = cmdArgs[2];
                int points = int.Parse(cmdArgs[3]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest] == currentPassword)
                    {
                        if (participants.ContainsKey(username))
                        {

                            if (participants[username].ContainsKey(contest))
                            {
                                if (participants[username][contest] < points)
                                {
                                    participants[username][contest] = points;
                                }
                            }
                            else
                            {
                                participants[username].Add(contest, points);
                            }

                        }
                        else
                        {

                            Dictionary<string, int> dict = new Dictionary<string, int>();
                            dict.Add(contest, points);
                            participants.Add(username, dict);
                        }
                    }
                }
            }
        }

        static void AddingContests(Dictionary<string, string> contests)
        {
            string command;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] cmdArgs = command.Split(":");
                string contestName = cmdArgs[0];
                string contestPassword = cmdArgs[1];

                contests.Add(contestName, contestPassword);
            }
        }
    }
}
