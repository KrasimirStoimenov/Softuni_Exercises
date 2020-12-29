using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> participants = new Dictionary<string, Dictionary<string, int>>();

            AddingContests(contests);
            ParticipateInContests(contests, participants);
            PrintBestCandidate(participants);
            PrintAllParticipants(participants);
        }


        static void PrintAllParticipants(Dictionary<string, Dictionary<string, int>> participants)
        {
            Console.WriteLine("Ranking:");
            foreach (var candidate in participants.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{candidate.Key}");
                foreach (var (contest, points) in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
        static void PrintBestCandidate(Dictionary<string, Dictionary<string, int>> participants)
        {
            int maxPoints = int.MinValue;
            string bestCandidateName = string.Empty;
            foreach (var candidate in participants)
            {
                int currentPoints = candidate.Value.Values.Sum();

                if (currentPoints > maxPoints)
                {
                    maxPoints = currentPoints;
                    bestCandidateName = candidate.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidateName} with total {maxPoints} points.");
        }

        static void ParticipateInContests(Dictionary<string, string> contests, Dictionary<string, Dictionary<string, int>> participants)
        {
            string participantInfo;
            while ((participantInfo = Console.ReadLine()) != "end of submissions")
            {
                //"{contest}=>{password}=>{username}=>{points}"
                string[] args = participantInfo.Split("=>").ToArray();
                string contest = args[0];
                string password = args[1];
                string username = args[2];
                int points = int.Parse(args[3]);
                if (contests.ContainsKey(contest))
                {
                    string contestPassword = contests[contest];
                    if (contestPassword == password)
                    {
                        if (!participants.ContainsKey(username))
                        {
                            participants.Add(username, new Dictionary<string, int>());
                        }
                        if (!participants[username].ContainsKey(contest))
                        {
                            participants[username].Add(contest, points);
                        }
                        else
                        {
                            if (participants[username][contest] < points)
                            {
                                participants[username][contest] = points;
                            }
                        }
                    }
                }
            }
        }

        static void AddingContests(Dictionary<string, string> contests)
        {
            string contest;
            while ((contest = Console.ReadLine()) != "end of contests")
            {
                //"{contest}:{password for contest}" 
                string[] contestArgs = contest.Split(":").ToArray();
                contests.Add(contestArgs[0], contestArgs[1]);
            }
        }
    }
}
