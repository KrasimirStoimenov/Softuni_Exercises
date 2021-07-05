namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> last;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var headNode = this.head;

            while (headNode != null)
            {
                var currentNodeValue = headNode.Value;

                if (currentNodeValue.Equals(item))
                {
                    return true;
                }

                headNode = headNode.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.CheckIfNotEmpty();

            var headReturned = this.head.Value;

            this.head = this.head.Next;
            this.Count--;

            return headReturned;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item);

            if (this.head == null)
            {
                this.head = newNode;
                this.last = newNode;
            }
            else
            {
                this.last.Next = newNode;
                last = newNode;
            }

            this.Count++;
        }

        public T Peek()
        {
            this.CheckIfNotEmpty();

            return this.head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void CheckIfNotEmpty()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}