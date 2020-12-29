using System.Collections.Generic;

using _08.CollectionHierarchy.Interfaces;

namespace _08.CollectionHierarchy.Models
{
    public class AddCollection : IAddable
    {
        private readonly ICollection<string> collection;
        private int index;
        public AddCollection()
        {
            this.collection = new List<string>();
            this.index = -1;
        }

        public int Add(string item)
        {
            index++;
            collection.Add(item);
            return index;
        }
    }
}
