namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[this.Count - 1 - index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    return this.Count - i - 1;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            for (int i = this.Count; i > this.Count - index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[this.Count - index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            for (int i = this.Count; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    for (int j = this.Count - i; j < this.Count - 1; j++)
                    {
                        this.items[j] = this.items[j + 1];
                    }
                    this.Count--;
                    return true;
                }
            }

            return false; ;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            this.items[this.Count - index] = default;

            for (int i = this.Count - index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count] = default;
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void Resize()
        {
            var newArray = new T[this.items.Length * 2];

            Array.Copy(this.items, newArray, this.Count);

            this.items = newArray;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}