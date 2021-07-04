namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException($"{nameof(capacity)} should be positive number!");
            }

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[index];
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
            for (int i = 0; i < this.items.Length; i++)
            {
                var currentItem = this.items[i];

                if (currentItem.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            var indexOfT = -1;

            for (int i = 0; i < this.items.Length; i++)
            {
                var currentItem = this.items[i];

                if (currentItem.Equals(item))
                {
                    indexOfT = i;

                    break;
                }
            }

            return indexOfT;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.Count++;

        }

        public bool Remove(T item)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                var currentItem = this.items[i];

                if (currentItem.Equals(item))
                {
                    for (int j = i; j < this.Count-1; j++)
                    {
                        this.items[j] = this.items[j + 1];
                    }

                    this.items[this.Count--] = default;

                    return true;
                }

            }

            return false;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < items.Length - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count--] = default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void Resize()
        {
            var newArray = new T[this.items.Length * 2];

            Array.Copy(this.items, newArray, this.items.Length);

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