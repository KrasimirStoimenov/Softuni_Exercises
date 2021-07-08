namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
                this.Count++;
                return;
            }

            var currentHead = this.head;
            this.head.Previous = newNode;
            this.head = newNode;
            this.head.Next = currentHead;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);

            if (this.Count == 0)
            {
                this.head = this.tail = newNode;
                this.Count++;
                return;
            }

            var lastNode = this.tail;
            this.tail.Next = newNode;
            this.tail = newNode;
            this.tail.Previous = lastNode;
            this.Count++;
        }

        public T GetFirst()
        {
            this.EnsureNotEmpty();

            return this.head.Item;
        }

        public T GetLast()
        {
            this.EnsureNotEmpty();

            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            this.EnsureNotEmpty();

            var removedHeadItem = this.head.Item;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
                this.Count--;
                return removedHeadItem;
            }

            this.head = this.head.Next;
            this.head.Previous = null;
            this.Count--;

            return removedHeadItem;
        }

        public T RemoveLast()
        {
            this.EnsureNotEmpty();

            var lastNodeItem = this.tail.Item;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
                this.Count--;
                return lastNodeItem;
            }

            this.tail = this.tail.Previous;
            this.tail.Next = null;
            this.Count--;

            return lastNodeItem;
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