namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public T Dequeue()
        {
            this.CheckIfNotEmpty();

            var element = this.elements[0];
            this.Swap(0, this.Size - 1);
            this.elements.RemoveAt(this.elements.Count - 1);

            this.HeapifyDown(0);

            return element;
        }

        private void HeapifyDown(int parentIndex)
        {
            var smallerChildIndex = this.FindSmallerChildIndex(parentIndex * 2 + 1, parentIndex * 2 + 2);

            while (smallerChildIndex != -1
                && IsSmaller(this.elements[smallerChildIndex], this.elements[parentIndex]))
            {
                Swap(smallerChildIndex, parentIndex);
                parentIndex = smallerChildIndex;
                smallerChildIndex = this.FindSmallerChildIndex(parentIndex * 2 + 1, parentIndex * 2 + 2);
            }
        }

        private int FindSmallerChildIndex(int leftChildIndex, int rightChildIndex)
        {
            if (leftChildIndex >= this.Size)
            {
                return -1;
            }

            if (rightChildIndex >= this.Size)
            {
                return leftChildIndex;
            }

            return this.IsSmaller(this.elements[leftChildIndex], this.elements[rightChildIndex]) ? leftChildIndex : rightChildIndex;
        }

        public void Add(T element)
        {
            this.elements.Add(element);
            if (this.Size > 1)
            {
                this.HeapifyUp(this.Size - 1);
            }
        }

        private void HeapifyUp(int index)
        {
            if (index == 0) return;

            var parentIndex = (index - 1) / 2;

            if (IsSmaller(this.elements[index], this.elements[parentIndex]))
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

        private bool IsGreater(T value, T other)
         => value.CompareTo(other) > 0;

        private bool IsSmaller(T value, T other)
            => value.CompareTo(other) < 0;

        public T Peek()
        {
            this.CheckIfNotEmpty();

            return this.elements[0];
        }

        private void CheckIfNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
