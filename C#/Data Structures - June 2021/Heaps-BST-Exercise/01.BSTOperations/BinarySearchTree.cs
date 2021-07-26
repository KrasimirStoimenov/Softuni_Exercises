namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        private int elementsCount = 0;

        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.Root = root;
        }

        public Node<T> Root { get; private set; }

        public int Count => elementsCount;

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
            this.elementsCount++;
            if (this.Root == null)
            {
                this.Root = new Node<T>(element, null, null);
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

        private IAbstractBinarySearchTree<T> DFSSearch(Node<T> root, T element)
        {
            if (element.CompareTo(root.Value) == 0)
            {
                return new BinarySearchTree<T>(root);
            }

            if (element.CompareTo(root.Value) < 0)
            {
                return DFSSearch(root.LeftChild, element);
            }
            else
            {
                return DFSSearch(root.RightChild, element);
            }
        }

        public void EachInOrder(Action<T> action)
        {
            DFSEachInOrder(this.Root, action);
        }

        private void DFSEachInOrder(Node<T> node, Action<T> action)
        {
            if (node.LeftChild != null)
            {
                DFSEachInOrder(node.LeftChild, action);
            }

            action.Invoke(node.Value);

            if (node.RightChild != null)
            {
                DFSEachInOrder(node.RightChild, action);
            }
        }

        public List<T> Range(T lower, T upper)
        {
            var validElements = new List<T>();
            DFSRange(this.Root, lower, upper, validElements);

            return validElements;
        }

        private void DFSRange(Node<T> node, T lower, T upper, List<T> validElements)
        {
            if (node.Value.CompareTo(lower) >= 0 && node.Value.CompareTo(upper) <= 0)
            {
                validElements.Add(node.Value);
            }

            if (node.LeftChild != null)
            {
                DFSRange(node.LeftChild, lower, upper, validElements);
            }

            if (node.RightChild != null)
            {
                DFSRange(node.RightChild, lower, upper, validElements);
            }
        }

        public void DeleteMin()
        {
            CheckIfNotEmpty();
            string minOrMax = "Min";
            DFSDelete(this.Root, minOrMax);

        }

        private void DFSDelete(Node<T> node, string minOrMax)
        {
            if (minOrMax == "Min")
            {
                if (node.LeftChild.LeftChild == null)
                {
                    if (node.LeftChild.RightChild != null)
                    {
                        node.LeftChild = node.LeftChild.RightChild;
                        node.LeftChild.RightChild = null;
                        return;
                    }
                    node.LeftChild = null;
                    this.elementsCount--;
                    return;
                }
                DFSDelete(node.LeftChild, minOrMax);
            }
            else
            {
                if (node.RightChild.RightChild == null)
                {
                    if (node.RightChild.LeftChild != null)
                    {
                        node.RightChild = node.RightChild.LeftChild;
                        node.RightChild.LeftChild = null;
                        return;
                    }
                    node.RightChild = null;
                    this.elementsCount--;
                    return;
                }
                DFSDelete(node.RightChild, minOrMax);
            }
        }

        public void DeleteMax()
        {
            CheckIfNotEmpty();
            string minOrMax = "Max";
            DFSDelete(this.Root, minOrMax);
        }

        public int GetRank(T element)
        {
            if (this.Root == null)
            {
                return 0;
            }

            int counter = 0;
            DFSGetRank(this.Root, ref counter, element);

            return counter;
        }

        private void DFSGetRank(Node<T> node, ref int counter, T element)
        {
            if (element.CompareTo(node.Value) > 0)
            {
                counter++;
            }

            if (node.LeftChild != null)
            {
                DFSGetRank(node.LeftChild, ref counter, element);
            }
            if (node.RightChild != null)
            {
                DFSGetRank(node.RightChild, ref counter, element);
            }
        }

        private void CheckIfNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
