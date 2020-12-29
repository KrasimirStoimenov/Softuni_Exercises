using System;
using System.Linq;
using System.Collections.Generic;

using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly HashSet<IPlayer> models;

        public PlayerRepository()
        {
            this.models = new HashSet<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => this.models;

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            this.models.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Username == name);
        }

        public bool Remove(IPlayer model)
        {
            return models.Remove(model);
        }
    }
}
