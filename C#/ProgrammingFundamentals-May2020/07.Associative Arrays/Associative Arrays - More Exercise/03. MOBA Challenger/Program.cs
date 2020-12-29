using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string/*user*/, Dictionary<string/*role*/, int/*points*/>> tierPlayers = new Dictionary<string, Dictionary<string, int>>();

            Proccessing(tierPlayers);
            PrintOutput(tierPlayers);
        }

        static void PrintOutput(Dictionary<string, Dictionary<string, int>> tierPlayers)
        {
            Dictionary<string, int> keepTotalPoints = new Dictionary<string, int>();

            foreach (var kvp in tierPlayers)            // getting total skill points
            {
                string currentUser = kvp.Key;
                int totalPoints = 0;
                foreach (var uvp in kvp.Value)
                {
                    totalPoints += uvp.Value;
                }
                keepTotalPoints.Add(currentUser, totalPoints);
            }

            foreach (var uvp in keepTotalPoints.OrderByDescending(x => x.Value).ThenBy(n => n.Key))
            {
                Console.WriteLine($"{uvp.Key}: {uvp.Value} skill");
                foreach (var kvp in tierPlayers[uvp.Key].OrderByDescending(x => x.Value).ThenBy(n => n.Key))
                {
                    Console.WriteLine($"- {kvp.Key} <::> {kvp.Value}");
                }
            }
        }

        static void Proccessing(Dictionary<string, Dictionary<string, int>> tierPlayers)
        {
            string command;
            while ((command = Console.ReadLine()) != "Season end")
            {
                string[] cmdArgs = command.Split(" ");

                if (cmdArgs.Length > 3)
                {
                    FillPlayersInTier(tierPlayers, cmdArgs);
                }
                else
                {
                    BattlePlayersInTier(tierPlayers, cmdArgs);
                }
            }
        }

        static void BattlePlayersInTier(Dictionary<string, Dictionary<string, int>> tierPlayers, string[] cmdArgs)
        {
            string firstPlayer = cmdArgs[0];
            string secondPlayer = cmdArgs[2];

            if (tierPlayers.ContainsKey(firstPlayer) && tierPlayers.ContainsKey(secondPlayer))
            {
                foreach (var kvp in tierPlayers[firstPlayer])
                {
                    if (tierPlayers[secondPlayer].ContainsKey(kvp.Key))
                    {
                        if (tierPlayers[firstPlayer][kvp.Key] > tierPlayers[secondPlayer][kvp.Key])
                        {
                            tierPlayers.Remove(secondPlayer);
                            break;
                        }
                        else if (tierPlayers[firstPlayer][kvp.Key] < tierPlayers[secondPlayer][kvp.Key])
                        {
                            tierPlayers.Remove(firstPlayer);
                            break;
                        }
                    }
                }
            }
        }

        static void FillPlayersInTier(Dictionary<string, Dictionary<string, int>> tierPlayers, string[] cmdArgs)
        {
            string user = cmdArgs[0];
            string role = cmdArgs[2];
            int damage = int.Parse(cmdArgs[4]);

            if (tierPlayers.ContainsKey(user))
            {
                if (tierPlayers[user].ContainsKey(role))
                {
                    if (tierPlayers[user][role] < damage)
                    {
                        tierPlayers[user][role] = damage;
                    }
                }
                else
                {
                    tierPlayers[user].Add(role, damage);
                }
            }
            else
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();
                dict.Add(role, damage);
                tierPlayers.Add(user, dict);
            }
        }
    }
}
