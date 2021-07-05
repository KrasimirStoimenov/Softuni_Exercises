namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var topNode = this.top;

            while (topNode != null)
            {
                var currentValue = topNode.Value;

                if (currentValue.Equals(item))
                {
                    return true;
                }

                topNode = topNode.Next;
            }

            return false;
        }

        public T Peek()
        {
            this.ValidateIfThereIsElementInTheStack();

            return this.top.Value;
        }

        public T Pop()
        {
            this.ValidateIfThereIsElementInTheStack();

            var removedNode = this.top.Value;
            this.top = this.top.Next;

            this.Count--;

            return removedNode;
        }

        public void Push(T item)
        {
            var newNode = new Node<T>(item);
            newNode.Next = this.top;

            this.top = newNode;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var topNode = this.top;

            while (topNode != null)
            {
                yield return topNode.Value;
                topNode = topNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void ValidateIfThereIsElementInTheStack()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
}