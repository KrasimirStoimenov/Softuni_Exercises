using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<int>>> participants = new Dictionary<string, Dictionary<string, List<int>>>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();
            Proccessing(participants, submissions);
            PrintOutput(participants, submissions);

        }

        static void PrintOutput(Dictionary<string, Dictionary<string, List<int>>> participants, Dictionary<string, int> submissions)
        {
            Dictionary<string, int> results = AddPeopleToResultDictionary(participants);

            Console.WriteLine($"Results:");

            foreach (var kvp in results.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var kvp in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }



        }

        static Dictionary<string, int> AddPeopleToResultDictionary(Dictionary<string, Dictionary<string, List<int>>> participants)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var kvp in participants)
            {
                string username = kvp.Key;
                int points = 0;
                foreach (var pair in kvp.Value)
                {
                    List<int> order = pair.Value.OrderByDescending(x => x).ToList();
                    points = order[0];
                }
                dict.Add(username, points);
            }

            return dict;
        }

        static void Proccessing(Dictionary<string, Dictionary<string, List<int>>> participants, Dictionary<string, int> submissions)
        {
            //"{username}-{language}-{points}

            string command;
            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] cmdArgs = command.Split("-", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (cmdArgs.Length == 2)
                {
                    string bannedUser = cmdArgs[0];
                    participants.Remove(bannedUser);
                    continue;
                }
                string username = cmdArgs[0];
                string language = cmdArgs[1];
                int point = int.Parse(cmdArgs[2]);

                if (submissions.ContainsKey(language))
                {
                    submissions[language]++;
                }
                else
                {
                    submissions.Add(language, 1);
                }


                if (participants.ContainsKey(username))
                {
                    if (participants[username].ContainsKey(language))
                    {
                        participants[username][language].Add(point);
                    }
                    else
                    {
                        participants[username].Add(language, new List<int> { point });
                    }
                }
                else
                {
                    Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
                    dict.Add(language, new List<int> { point });
                    participants.Add(username, dict);
                }
            }
        }
    }
}
