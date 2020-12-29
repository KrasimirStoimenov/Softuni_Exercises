using System.Collections.Generic;

using _08.CollectionHierarchy.Interfaces;

namespace _08.CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddable, IRemovable
    {
        private readonly List<string> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }
        public int Add(string item)
        {
            this.collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string removedElement = this.collection[this.collection.Count - 1];
            this.collection.RemoveAt(this.collection.Count - 1);
            return removedElement;
        }
    }
}
