namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var firstElementAncestors = new List<T>();
            this.Search(this, first, firstElementAncestors);

            var secondElementAncestors = new List<T>();
            this.Search(this, second, secondElementAncestors);

            var intersectedElements = firstElementAncestors.Intersect(secondElementAncestors).Reverse().ToArray();

            return intersectedElements[0];
        }

        private void Search(BinaryTree<T> node, T element, List<T> elementAncestors)
        {
            if (node == null)
            {
                return;
            }

            elementAncestors.Add(node.Value);

            if (element.CompareTo(node.Value) < 0)
            {

                Search(node.LeftChild, element, elementAncestors);
            }
            else
            {
                Search(node.RightChild, element, elementAncestors);
            }

        }
    }
}
