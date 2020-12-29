using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index;

        public Stack()
        {
            this.list = new List<T>();
            this.index = -1;
        }
        public int Count => this.list.Count;
        public void Push(T element)
        {

            index++;
            this.list.Add(element);
        }

        public T Pop()
        {
            if (list.Count == 0)
            {
                return default;
            }
            T lastElement = this.list[index];
            list.RemoveAt(index);
            index--;
            return lastElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = index; i >= 0; i--)
            {
                yield return this.list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
