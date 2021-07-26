namespace _04.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.Root = root;
            this.LeftChild = root.LeftChild;
            this.RightChild = root.RightChild;
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public bool Contains(T element)
        {
            return DFSContains(this.Root, element);
        }

        private bool DFSContains(Node<T> node, T element)
        {
            if (node == null)
            {
                return false;
            }

            if (element.CompareTo(node.Value) == 0)
            {
                return true;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                return DFSContains(node.LeftChild, element);
            }
            else
            {
                return DFSContains(node.RightChild, element);
            }

        }

        public void Insert(T element)
        {
            if (this.Root == null)
            {
                var node = new Node<T>(element, null, null);
                this.Root = node;
                return;
            }

            DFSInsert(this.Root, element);
        }

        private void DFSInsert(Node<T> node, T element)
        {
            if (element.CompareTo(node.Value) < 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new Node<T>(element, null, null);
                    return;
                }

                DFSInsert(node.LeftChild, element);
            }
            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new Node<T>(element, null, null);
                    return;
                }

                DFSInsert(node.RightChild, element);
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            return DFSSearch(this.Root, element);
        }

        private IAbstractBinarySearchTree<T> DFSSearch(Node<T> node, T element)
        {
            if (element.CompareTo(node.Value) == 0)
            {
                return new BinarySearchTree<T>(node);
            }

            if (element.CompareTo(node.Value) < 0)
            {
                return DFSSearch(node.LeftChild, element);
            }
            else
            {
                return DFSSearch(node.RightChild, element);
            }
        }
    }
}
