using System.Collections.Generic;

using _07.MilitaryElite.Models;

namespace _07.MilitaryElite.Interfaces
{
    public interface IEngineer
    {
         ICollection<IRepair> Repairs { get; }
    }
}
