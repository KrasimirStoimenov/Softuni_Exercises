using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index;

        public ListyIterator()
        {
            this.list = new List<T>();
            this.index = 0;
        }
        public void Create(params T[] initialParameters)
        {
            this.list = initialParameters.ToList();
        }
        public bool Move()
        {
            if (list.Count > index + 1)
            {
                index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (list.Count > index + 1)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.list[index]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.list.Count; i++)
            {
                yield return this.list[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

