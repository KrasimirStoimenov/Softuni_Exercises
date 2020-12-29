using System;
using System.Linq;
using System.Collections.Generic;

using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly HashSet<IGun> models;

        public GunRepository()
        {
            this.models = new HashSet<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => this.models;

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            this.models.Add(model);
        }

        public IGun FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IGun model)
        {         
            return models.Remove(model);
        }
    }
}
