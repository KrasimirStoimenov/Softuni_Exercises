using System.Linq;
using System.Collections.Generic;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private ICollection<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public void Add(ICar model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.models.ToList().AsReadOnly();
        }

        public ICar GetByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Model == name);

        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }
    }
}
