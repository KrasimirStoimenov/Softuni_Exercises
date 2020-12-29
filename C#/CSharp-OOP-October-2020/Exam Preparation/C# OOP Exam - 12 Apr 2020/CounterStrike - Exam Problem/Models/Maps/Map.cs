using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            string firstTeamName = "Terrorist";
            string secondTeamName = "CounterTerrorist";

            HashSet<IPlayer> terrorists = players.Where(t => t.GetType().Name == firstTeamName).ToHashSet();
            HashSet<IPlayer> counterTerrorists = players.Where(t => t.GetType().Name == secondTeamName).ToHashSet();

            string teamWon = TakeWinningTeam(terrorists, counterTerrorists);

            return teamWon;
        }

        private string TakeWinningTeam(HashSet<IPlayer> terrorists, HashSet<IPlayer> counterTerrorists)
        {
            while (true)
            {
                Attack(terrorists, counterTerrorists);
                if (!counterTerrorists.Any(x => x.IsAlive == true))
                {
                    return "Terrorist wins!";
                }
                Attack(counterTerrorists, terrorists);
                if (!terrorists.Any(x => x.IsAlive == true))
                {
                    return "Counter Terrorist wins!";
                }
            }
        }

        private void Attack(HashSet<IPlayer> team, HashSet<IPlayer> attackedTeam)
        {
            foreach (var attacker in team.Where(x => x.IsAlive == true))
            {
                var damageInflict = attacker.Gun.Fire();
                foreach (var player in attackedTeam.Where(x => x.IsAlive == true))
                {
                    player.TakeDamage(damageInflict);
                }
            }
        }
    }
}
