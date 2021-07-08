namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var node = this.head;

            while (node != null)
            {
                if (node.Item.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.EnsureNotEmpty();

            var oldHeadItem = this.head.Item;

            if (this.head.Next == null)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.Next;
            }

            this.Count--;

            return oldHeadItem;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item, null);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
                this.Count++;
                return;
            }

            this.tail.Next = newNode;
            this.tail = this.tail.Next;
            this.Count++;
        }

        public T Peek()
        {
            this.EnsureNotEmpty();

            return this.head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.head;

            while (node != null)
            {
                yield return node.Item;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}