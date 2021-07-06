namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item);

            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                newNode.Next = this.head;
                this.head = newNode;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);

            if (this.head == null)
            {
                this.head = newNode;
            }
            else
            {
                var last = this.GetLastNode();

                last.Next = newNode;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.CheckIfNotEmpty();

            return this.head.Value;
        }

        public T GetLast()
        {
            this.CheckIfNotEmpty();

            var lastNode = this.GetLastNode();

            return lastNode.Value;
        }

        public T RemoveFirst()
        {
            this.CheckIfNotEmpty();

            var firstValue = this.head.Value;

            var currentHead = this.head;

            var newHead = this.head.Next;

            currentHead = null;

            this.head = newHead;

            this.Count--;

            return firstValue;
        }

        public T RemoveLast()
        {
            this.CheckIfNotEmpty();

            var lastElement = this.GetLastNode();

            var lastValue = lastElement.Value;

            if (this.head.Next == null)
            {
                this.head = null;
                this.Count--;

                return lastValue;
            }

            var newLast = this.head;

            while (newLast.Next.Next != null)
            {
                newLast = newLast.Next;
            }

            newLast.Next = null;

            this.Count--;

            return lastValue;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElement = this.head;

            while (currentElement != null)
            {
                yield return currentElement.Value;
                currentElement = currentElement.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private Node<T> GetLastNode()
        {
            var lastNode = this.head;

            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }

            return lastNode;
        }

        private void CheckIfNotEmpty()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}