using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string/*participant*/, int/*distance*/> participants = new Dictionary<string, int>();
            AddingParticipants(participants);
            Proccessing(participants);
            PrintOutput(participants);

        }

        static void PrintOutput(Dictionary<string, int> participants)
        {
            string first = string.Empty;
            string second = string.Empty;
            string third = string.Empty;

            int counter = 1;
            foreach (var participant in participants.OrderByDescending(d => d.Value))
            {
                if (counter == 1)
                {
                    first = participant.Key;
                    counter++;
                }
                else if (counter == 2)
                {
                    second = participant.Key;
                    counter++;
                }
                else if (counter == 3)
                {
                    third = participant.Key;
                    break;
                }
            }

            Console.WriteLine($"1st place: {first}");
            Console.WriteLine($"2nd place: {second}");
            Console.WriteLine($"3rd place: {third}");
        }

        static void Proccessing(Dictionary<string, int> participants)
        {
            string participantPattern = @"[A-Za-z]";
            string distancePattern = @"\d";
            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                MatchCollection participantMatch = Regex.Matches(input, participantPattern);
                string currentParticipant = GetParticipantOutOfMatchCollection(participantMatch);
                MatchCollection distanceMatch = Regex.Matches(input, distancePattern);
                int currentDistanceRun = GetCurrentDistanceRun(distanceMatch);
                if (participants.ContainsKey(currentParticipant))
                {
                    participants[currentParticipant] += currentDistanceRun;
                }
            }
        }

        static int GetCurrentDistanceRun(MatchCollection distanceMatch)
        {
            int distance = 0;
            foreach (Match match in distanceMatch)
            {
                string current = match.ToString();
                distance += int.Parse(current);
            }

            return distance;
        }

        static string GetParticipantOutOfMatchCollection(MatchCollection participantMatch)
        {
            string name = string.Empty;
            foreach (Match letter in participantMatch)
            {
                name += letter;
            }
            return name;
        }

        static void AddingParticipants(Dictionary<string, int> participants)
        {
            string[] users = Console.ReadLine()
                .Split(", ")
                .ToArray();

            foreach (var user in users)
            {
                participants.Add(user, 0);
            }
        }
    }
}
