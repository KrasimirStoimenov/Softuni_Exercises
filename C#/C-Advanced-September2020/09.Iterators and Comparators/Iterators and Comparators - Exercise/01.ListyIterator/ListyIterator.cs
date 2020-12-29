using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
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
    }
}
