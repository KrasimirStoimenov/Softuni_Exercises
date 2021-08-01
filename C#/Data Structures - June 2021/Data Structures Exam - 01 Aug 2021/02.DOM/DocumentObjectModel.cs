namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;
        }

        public DocumentObjectModel()
        {
            this.Root = new HtmlElement(ElementType.Document,
                     new HtmlElement(ElementType.Html,
                         new HtmlElement(ElementType.Head),
                         new HtmlElement(ElementType.Body)));

        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            var elements = this.OrderBfs();
            foreach (var element in elements)
            {
                if (element.Type == type)
                {
                    return element;
                }
            }

            return null;
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            var elements = this.OrderDfs().Where(e => e.Type == type);

            return elements.ToList();
        }

        public bool Contains(IHtmlElement htmlElement)
            => this.FindBfs(htmlElement) != null ? true : false;

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            var currentParent = this.FindBfs(parent);
            this.CheckIfExists(currentParent);

            var childrens = currentParent.Children.ToArray();
            currentParent.Children.Clear();
            child.Parent = currentParent;
            currentParent.Children.Add(child);

            foreach (var currentChild in childrens)
            {
                currentParent.Children.Add(currentChild);
            }

        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            var currentParent = this.FindBfs(parent);
            this.CheckIfExists(currentParent);

            child.Parent = currentParent;
            currentParent.Children.Add(child);
        }

        public void Remove(IHtmlElement htmlElement)
        {
            var searchedElement = this.FindBfs(htmlElement);
            this.CheckIfExists(searchedElement);

            foreach (var child in searchedElement.Children)
            {
                child.Parent = null;
            }

            searchedElement.Children.Clear();

            IHtmlElement searchedParent = searchedElement.Parent;

            searchedParent.Children.Remove(searchedElement);

            searchedElement = default;
        }

        public void RemoveAll(ElementType elementType)
        {
            var elements = this.OrderBfs();

            foreach (var element in elements)
            {
                if (element.Type == elementType)
                {
                    this.Remove(element);
                }
            }
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            IHtmlElement element = this.FindBfs(htmlElement);
            this.CheckIfExists(element);
            if (element.Attributes.ContainsKey(attrKey))
            {
                return false;
            }

            element.Attributes.Add(attrKey, attrValue);
            return true;
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            IHtmlElement element = this.FindBfs(htmlElement);
            this.CheckIfExists(element);
            if (element.Attributes.ContainsKey(attrKey))
            {
                element.Attributes.Remove(attrKey);
                return true;
            }

            return false;
        }

        public IHtmlElement GetElementById(string idValue)
        {
            var elements = this.OrderBfs();

            foreach (var element in elements)
            {
                if (element.Attributes.ContainsKey("id"))
                {
                    return element;
                }
            }

            return null;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            return GetTreeAsString(this.Root, 0, sb);
        }

        private void CheckIfExists(IHtmlElement element)
        {
            if (element == null)
            {
                throw new InvalidOperationException();
            }
        }

        private ICollection<IHtmlElement> OrderBfs()
        {
            var treeNodes = new List<IHtmlElement>();

            treeNodes.Add(this.Root);

            var queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var childTree = queue.Dequeue();
                foreach (var child in childTree.Children)
                {
                    queue.Enqueue(child);
                    treeNodes.Add(child);
                }
            }

            return treeNodes;
        }

        private IHtmlElement FindBfs(IHtmlElement parentKey)
        {
            var queue = new Queue<IHtmlElement>();
            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var childTree = queue.Dequeue();

                if (childTree.Equals(parentKey))
                {
                    return childTree;
                }

                foreach (var tree in childTree.Children)
                {
                    if (tree.Equals(parentKey))
                    {
                        return tree;
                    }

                    queue.Enqueue(tree);
                }
            }

            return null;
        }

        private ICollection<IHtmlElement> OrderDfs()
        {
            var treeNodes = new List<IHtmlElement>();

            this.Dfs(this.Root, treeNodes);

            return treeNodes;
        }

        private void Dfs(IHtmlElement node, List<IHtmlElement> treeNodes)
        {
            foreach (var child in node.Children)
            {
                this.Dfs(child, treeNodes);
            }

            treeNodes.Add(node);
        }

        private string GetTreeAsString(IHtmlElement tree, int level, StringBuilder sb)
        {

            var valueToAppend = $"{new string(' ', level)}{tree.Type}";

            sb.AppendLine(valueToAppend);

            foreach (var child in tree.Children)
            {
                GetTreeAsString(child, level + 2, sb);
            }

            return sb.ToString();
        }

    }
}
