namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private Stack<ILink> stack;
        private DoublyLinkedList<ILink> linkedList;
        private int elementsCount;

        public BrowserHistory()
        {
            this.stack = new Stack<ILink>();
            this.linkedList = new DoublyLinkedList<ILink>();
        }

        public int Size => this.elementsCount;

        public void Clear()
        {
            this.elementsCount = 0;
            this.stack.Clear();
        }

        public bool Contains(ILink link)
            => this.stack.Contains(link);

        public ILink DeleteFirst()
        {
            this.elementsCount--;
            return this.linkedList.RemoveFirst();
        }

        public ILink DeleteLast()
        {
            this.elementsCount--;
            return this.linkedList.RemoveLast();
        }

        public ILink GetByUrl(string url)
        {
            foreach (var item in this.stack)
            {
                if (item.Url.Equals(url))
                {
                    return item;
                }
            }

            return null;
        }

        public ILink LastVisited()
        {
            this.CheckIfNotEmpty();

            return this.stack.Peek();
        }


        public void Open(ILink link)
        {
            this.stack.Push(link);
            this.linkedList.AddLast(link);
            this.elementsCount++;
        }

        public int RemoveLinks(string url)
        {
            var newStack = new Stack<ILink>();

            var counter = 0;
            while (this.stack.Count > 0)
            {
                var element = this.stack.Pop();
                if (element.Url.Contains(url))
                {
                    counter++;
                    continue;
                }

                newStack.Push(element);
            }

            if (counter == 0)
            {
                throw new InvalidOperationException();
            }

            this.elementsCount -= counter;
            this.stack = newStack;

            return counter;
        }

        public ILink[] ToArray()
            => this.stack.ToArray();

        public List<ILink> ToList()
            => new List<ILink>(this.stack);

        public string ViewHistory()
        {
            if (this.stack.Count == 0)
            {
                return "Browser history is empty!";
            }

            var sb = new StringBuilder();
            while (this.stack.Count > 0)
            {
                sb.AppendLine(this.stack.Pop().ToString());
            }

            return sb.ToString();
        }

        private void CheckIfNotEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
