using System.Linq;
using System.Collections.Generic;

using EasterRaces.Repositories.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private ICollection<IDriver> models;

        public DriverRepository()
        {
            this.models = new List<IDriver>();
        }

        public void Add(IDriver model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.models.ToList().AsReadOnly();
        }

        public IDriver GetByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);

        }

        public bool Remove(IDriver model)
        {
            return this.models.Remove(model);
        }
    }
}
