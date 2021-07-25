namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private readonly List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
            if (this.Size > 1)
            {
                this.HeapifyUp(this.Size - 1);
            }
        }

        public T Peek()
        {
            HasElements();

            return this.elements[0];
        }

        private void HeapifyUp(int index)
        {
            if (index == 0) return;

            var parentIndex = (index - 1) / 2;

            if (IsGreater(index, parentIndex))
            {
                Swap(index, parentIndex);
                HeapifyUp(parentIndex);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = this.elements[index];
            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = temp;
        }

        private bool IsGreater(int index, int parentIndex)
        {
            if (this.elements[index].CompareTo(this.elements[parentIndex]) > 0)
            {
                return true;
            }

            return false;
        }

        private void HasElements()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
