using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomStack
    {
        private int[] items;
        private const int INITIAL_CAPACITY = 4;

        public CustomStack()
        {
            this.items = new int[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }

        public void Push(int element)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }
            this.items[Count] = element;
            Count++;
        }

        public int Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
            int lastElement = this.items[this.Count - 1];
            this.items[this.Count - 1] = default;
            this.Count--;
            return lastElement;
        }

        public int Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
            int lastElement = this.items[this.Count - 1];
            return lastElement;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }
    }
}
