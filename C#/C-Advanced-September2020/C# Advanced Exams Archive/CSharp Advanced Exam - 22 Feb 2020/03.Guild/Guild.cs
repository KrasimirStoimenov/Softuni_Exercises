using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }
        public int Count => this.roster.Count;
        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            Player player = roster.Find(x => x.Name == name);
            if (player != null)
            {
                roster.Remove(player);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);
            player.Rank = "Member";
        }
        public void DemotePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);
            player.Rank = "Trial";
        }
        public Player[] KickPlayersByClass(string @class)
        {
            Player[] kickedPlayers = roster.Where(x => x.Class == @class).ToArray();
            roster.RemoveAll(x => x.Class == @class);

            return kickedPlayers.ToArray();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
