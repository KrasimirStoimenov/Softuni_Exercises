using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        public ListNode Head { get; set; }

        public ListNode Tail { get; set; }

        public int Count { get; set; }

        public void AddFirst(int element)
        {
            if (this.Count == 0)
            {
                this.Head = this.Tail = new ListNode(element);
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = this.Head;
                this.Head.PreviousNode = newHead;
                this.Head = newHead;
            }
            this.Count++;
        }
        public void AddLast(int element)
        {
            if (this.Count == 0)
            {
                this.Tail = this.Head = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.PreviousNode = this.Tail;
                this.Tail.NextNode = newTail;
                this.Tail = newTail;
            }

            this.Count++;
        }

        public int RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            int firstElement = this.Head.Value;
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

        public int RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            int lastElement = this.Tail.Value;
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

        public void ForEach(Action<int> action)
        {
            ListNode currentNode = this.Head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];
            int index = 0;
            ListNode currentNode = this.Head;
            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }

            return array;
        }

    }
}
