namespace _02.Data
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T>
        where T : IComparable<T>
    {
        private readonly List<T> elements;

        public PriorityQueue()
        {
            this.elements = new List<T>();
        }

        public List<T> AsList => this.elements;

        public int Size => this.elements.Count;

        public T Dequeue()
        {
            HasElements();
            var priorityElement = this.Peek();
            this.Swap(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);

            if (this.elements.Count > 1)
            {
                this.HeapifyDown(0);
            }
            return priorityElement;
        }

        private void HeapifyDown(int index)
        {
            if (index == this.Size) return;

            var leftChildIndex = 2 * index + 1;
            var rightChildIndex = 2 * index + 2;

            if (leftChildIndex >= this.Size) return;

            var biggerChildIndex = leftChildIndex;

            if ((rightChildIndex < this.Size) && this.elements[rightChildIndex].CompareTo(this.elements[leftChildIndex]) > 0)
            {
                biggerChildIndex = rightChildIndex;
            }

            if (this.elements[index].CompareTo(this.elements[biggerChildIndex]) < 0)
            {
                this.Swap(index, biggerChildIndex);
                HeapifyDown(biggerChildIndex);
            }

        }
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

        private void HasElements()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private void HeapifyUp(int index)
        {
            if (index == 0) return;

            var parentIndex = (index - 1) / 2;

            if (this.IsGreater(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                this.HeapifyUp(parentIndex);
            }
        }

        private bool IsGreater(int index, int parentIndex)
            => this.elements[index].CompareTo(this.elements[parentIndex]) > 0 ? true : false;

        private void Swap(int index, int parentIndex)
        {
            var temp = this.elements[index];
            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = temp;
        }
    }
}
