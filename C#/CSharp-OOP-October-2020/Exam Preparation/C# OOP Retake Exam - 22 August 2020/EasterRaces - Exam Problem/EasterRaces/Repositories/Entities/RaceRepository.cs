using System.Linq;
using System.Collections.Generic;

using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private ICollection<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.models.ToList().AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);

        }

        public bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }
    }
}
