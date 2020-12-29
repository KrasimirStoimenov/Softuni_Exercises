using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmdArgs = command.Split(";", StringSplitOptions.None).ToArray();
                    string action = cmdArgs[0];
                    switch (action)
                    {
                        case "Team":
                            AddTeamToTeams(teams, cmdArgs);
                            break;
                        case "Add":
                            AddPlayerToTheTeam(teams, cmdArgs);
                            break;
                        case "Remove":
                            RemovePlayerFromTheTeam(teams, cmdArgs);
                            break;
                        case "Rating":
                            PrintRating(teams, cmdArgs);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void PrintRating(List<Team> teams, string[] cmdArgs)
        {
            string teamName = cmdArgs[1];
            Team currentTeam = teams.FirstOrDefault(x => x.Name == teamName);
            if (currentTeam == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            Console.WriteLine($"{currentTeam.Name} - {currentTeam.Rating}");
        }

        private static void RemovePlayerFromTheTeam(List<Team> teams, string[] cmdArgs)
        {
            string teamName = cmdArgs[1];
            string playerName = cmdArgs[2];
            Team currentTeam = teams.FirstOrDefault(x => x.Name == teamName);
            currentTeam.RemovePlayer(playerName);
        }

        private static void AddPlayerToTheTeam(List<Team> teams, string[] cmdArgs)
        {
            string teamName = cmdArgs[1];
            Team currentTeam = teams.FirstOrDefault(x => x.Name == teamName);
            if (currentTeam == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }
            string playerName = cmdArgs[2];
            Stats stats = GetStats(cmdArgs);
            Player player = new Player(playerName, stats);
            currentTeam.AddPlayer(player);
        }

        private static Stats GetStats(string[] cmdArgs)
        {
            int endurance = int.Parse(cmdArgs[3]);
            int sprint = int.Parse(cmdArgs[4]);
            int dribble = int.Parse(cmdArgs[5]);
            int passing = int.Parse(cmdArgs[6]);
            int shooting = int.Parse(cmdArgs[7]);

            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);

            return stats;
        }

        private static void AddTeamToTeams(List<Team> teams, string[] cmdArgs)
        {
            string teamName = cmdArgs[1];
            Team currentTeam = new Team(teamName);
            teams.Add(currentTeam);
        }
    }
}
