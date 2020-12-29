using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }
        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }
                return (int)Math.Round(this.players.Sum(x => x.Stats.GetSkillLevel()) / this.players.Count);
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player currentPlayer = this.players.FirstOrDefault(x => x.Name == playerName);
            if (currentPlayer == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            this.players.Remove(currentPlayer);
        }
    }
}
