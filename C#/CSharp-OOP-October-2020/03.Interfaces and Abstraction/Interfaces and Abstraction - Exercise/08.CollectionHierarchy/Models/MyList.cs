using System.Collections.Generic;

using _08.CollectionHierarchy.Interfaces;

namespace _08.CollectionHierarchy.Models
{
    public class MyList : IAddable, IRemovable
    {
        private readonly List<string> collection;

        public MyList()
        {
            this.collection = new List<string>();
        }

        public int Used => this.collection.Count;

        public int Add(string item)
        {
            this.collection.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string removedElement = this.collection[0];
            this.collection.RemoveAt(0);
            return removedElement;
        }
    }
}
