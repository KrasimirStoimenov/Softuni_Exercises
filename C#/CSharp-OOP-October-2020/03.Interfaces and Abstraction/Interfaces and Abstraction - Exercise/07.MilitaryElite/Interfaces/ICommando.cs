using _07.MilitaryElite.Models;
using System.Collections.Generic;

namespace _07.MilitaryElite.Interfaces
{
    public interface ICommando
    {
         ICollection<IMission> Missions { get; }
    }
}
