using System.Collections.Generic;
using System.Text;
using _07.MilitaryElite.Interfaces;

namespace _07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public ICollection<IPrivate> Privates { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var @private in this.Privates)
            {
                sb.AppendLine("  " + @private.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
