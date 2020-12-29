using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _07.CustomLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public ListNode<T> Head { get; set; }

        public ListNode<T> Tail { get; set; }

        public int Count { get; set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.Head = this.Tail = new ListNode<T>(element);
            }
            else
            {
                var newHead = new ListNode<T>(element);
                newHead.NextNode = this.Head;
                this.Head.PreviousNode = newHead;
                this.Head = newHead;
            }
            this.Count++;
        }
        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.Tail = this.Head = new ListNode<T>(element);
            }
            else
            {
                var newTail = new ListNode<T>(element);
                newTail.PreviousNode = this.Tail;
                this.Tail.NextNode = newTail;
                this.Tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T firstElement = this.Head.Value;
            this.Head = this.Head.NextNode;
            if (this.Head == null)
            {
                this.Tail = null;
            }
            else
            {
                this.Head.PreviousNode = null;
            }

            this.Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T lastElement = this.Tail.Value;
            this.Tail = this.Tail.PreviousNode;
            if (this.Tail != null)
            {
                this.Tail.NextNode = null;
            }
            else
            {
                this.Head = null;
            }
            this.Count--;
            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currentNode = this.Head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            int index = 0;
            ListNode<T> currentNode = this.Head;
            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            T[] array = new T[this.Count];
            int index = 0;
            ListNode<T> currentNode = this.Head;
            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }
            for (int i = 0; i < array.Length ; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
