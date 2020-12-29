using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ICollection<IPlayer> models;

        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }
        public int Count => this.models.Count;

        public IReadOnlyCollection<IPlayer> Players => this.models.ToList().AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            if (this.models.Any(x => x.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            this.models.Add(player);
        }


        public IPlayer Find(string username)
        {
            return this.models.FirstOrDefault(x => x.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            return this.models.Remove(player);
        }
    }
}
