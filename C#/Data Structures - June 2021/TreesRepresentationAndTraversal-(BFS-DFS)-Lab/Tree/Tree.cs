namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;
        private bool IsRootDeleted = false;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            var treeNodes = new List<T>();

            if (this.IsRootDeleted)
            {
                return treeNodes;
            }

            treeNodes.Add(this.Value);

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var childTree = queue.Dequeue();
                foreach (var child in childTree.Children)
                {
                    queue.Enqueue(child);
                    treeNodes.Add(child.Value);
                }
            }

            return treeNodes;
        }

        public ICollection<T> OrderDfs()
        {
            var treeNodes = new List<T>();

            if (this.IsRootDeleted)
            {
                return treeNodes;
            }

            this.Dfs(this, treeNodes);

            return treeNodes;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentTree = this.FindBfs(parentKey);

            if (parentTree == null)
            {
                throw new ArgumentNullException();
            }

            parentTree.children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            var searchedNode = this.FindBfs(nodeKey);

            if (searchedNode == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var child in searchedNode.children)
            {
                child.Parent = null;
            }

            searchedNode.children.Clear();

            Tree<T> searchedParent = searchedNode.Parent;

            if (searchedParent == null)
            {
                this.IsRootDeleted = true;
            }
            else
            {
                searchedParent.children.Remove(searchedNode);
            }
            searchedNode.Value = default;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindBfs(firstKey);
            var secondNode = this.FindBfs(secondKey);

            if (firstNode == null || secondNode == null)
            {
                throw new ArgumentNullException();
            }

            var firstNodeParent = firstNode.Parent;
            var secondNodeParent = secondNode.Parent;

            if (firstNodeParent == null)
            {
                SwapRoot(secondNode);
                return;
            }
            else if (secondNodeParent == null)
            {
                SwapRoot(firstNode);
                return;
            }

            firstNode.Parent = secondNodeParent;
            secondNode.Parent = firstNodeParent;

            var indexOfFirst = firstNodeParent.children.IndexOf(firstNode);
            var indexOfSecond = secondNodeParent.children.IndexOf(secondNode);

            firstNodeParent.children[indexOfFirst] = secondNode;
            secondNodeParent.children[indexOfSecond] = firstNode;
        }

        private void SwapRoot(Tree<T> node)
        {
            this.Value = node.Value;
            this.Parent = null;
            this.children.Clear();
            this.children.AddRange(node.children);
            node.Parent = null;
        }

        private Tree<T> FindBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var childTree = queue.Dequeue();

                if (childTree.Value.Equals(parentKey))
                {
                    return childTree;
                }

                foreach (var tree in childTree.children)
                {
                    if (tree.Value.Equals(parentKey))
                    {
                        return tree;
                    }

                    queue.Enqueue(tree);
                }
            }

            return null;
        }

        private void Dfs(Tree<T> currentTree, List<T> treeNodes)
        {
            foreach (var child in currentTree.children)
            {
                this.Dfs(child, treeNodes);
            }

            treeNodes.Add(currentTree.Value);
        }
    }
}
