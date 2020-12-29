using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomList
    {
        private const int INITIAL_CAPACITY = 2;

        private int[] items;

        public CustomList()
        {
            this.items = new int[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (!ValidateIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (!ValidateIndex(index))
                {
                    throw new IndexOutOfRangeException();
                }

                this.items[index] = value;
            }
        }

        public void Add(int element)
        {
            if (this.items.Length == this.Count)
            {
                Resize();
            }

            this.items[Count] = element;
            Count++;
        }
        public int RemoveAt(int index)
        {
            if (!ValidateIndex(index))
            {
                throw new IndexOutOfRangeException();
            }

            int removedItem = this.items[index];
            this.items[index] = default;
            this.ShiftLeft(index);
            this.items[this.Count - 1] = default;
            this.Count--;
            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }
            return removedItem;
        }
        public void Insert(int index, int element)
        {
            if (!ValidateIndex(index))
            {
                throw new IndexOutOfRangeException();
            }
            if (this.Count == this.items.Length)
            {
                Resize();
            }

            this.ShiftRight(index);
            this.items[index] = element;
            this.Count++;

        }
        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            if (!ValidateIndex(firstIndex) || !ValidateIndex(secondIndex))
            {
                throw new IndexOutOfRangeException();
            }
            int firstElement = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = firstElement;
        }
        public void Reverse()
        {
            int[] copy = new int[this.items.Length];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[this.Count - 1 - i];
            }
            this.items = copy;
        }
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
        private void Shrink()
        {
            int[] copyArray = new int[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                copyArray[i] = this.items[i];
            }

            this.items = copyArray;
        }
        private void Resize()
        {
            int[] copyArray = new int[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                copyArray[i] = this.items[i];
            }

            this.items = copyArray;
        }
        private bool ValidateIndex(int index)
        {
            if (index >= 0 && index <= this.Count)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < this.items.Length; i++)
            {
                sb.Append(this.items[i] + " ");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
