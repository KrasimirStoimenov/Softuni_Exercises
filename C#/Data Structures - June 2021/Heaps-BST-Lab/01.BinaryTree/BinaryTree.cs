namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            var sb = new StringBuilder();

            DFSPreOrderString(this, indent, sb);

            return sb.ToString();
        }

        private void DFSPreOrderString(IAbstractBinaryTree<T> binaryTree, int indent, StringBuilder sb)
        {
            sb.AppendLine($"{new string(' ', indent)}{binaryTree.Value}");

            if (binaryTree.LeftChild != null)
            {
                DFSPreOrderString(binaryTree.LeftChild, indent + 2, sb);
            }

            if (binaryTree.RightChild != null)
            {
                DFSPreOrderString(binaryTree.RightChild, indent + 2, sb);
            }
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            var inOrderTree = new List<IAbstractBinaryTree<T>>();
            DFSInOrder(this, inOrderTree);

            return inOrderTree;
        }

        private void DFSInOrder(IAbstractBinaryTree<T> binaryTree, List<IAbstractBinaryTree<T>> inOrderTree)
        {
            if (binaryTree.LeftChild != null)
            {
                DFSInOrder(binaryTree.LeftChild, inOrderTree);
            }

            inOrderTree.Add(binaryTree);

            if (binaryTree.RightChild != null)
            {
                DFSInOrder(binaryTree.RightChild, inOrderTree);
            }
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            var postOrderTree = new List<IAbstractBinaryTree<T>>();

            DFSPostOrder(this, postOrderTree);

            return postOrderTree;
        }

        private void DFSPostOrder(IAbstractBinaryTree<T> binaryTree, List<IAbstractBinaryTree<T>> postOrderTree)
        {
            if (binaryTree.LeftChild != null)
            {
                DFSPostOrder(binaryTree.LeftChild, postOrderTree);
            }

            if (binaryTree.RightChild != null)
            {
                DFSPostOrder(binaryTree.RightChild, postOrderTree);
            }

            postOrderTree.Add(binaryTree);
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            var preOrderTree = new List<IAbstractBinaryTree<T>>();

            DFSPreOrder(this, preOrderTree);

            return preOrderTree;
        }

        private void DFSPreOrder(IAbstractBinaryTree<T> binaryTree, List<IAbstractBinaryTree<T>> preOrderTree)
        {
            preOrderTree.Add(binaryTree);

            if (binaryTree.LeftChild != null)
            {
                DFSPreOrder(binaryTree.LeftChild, preOrderTree);
            }

            if (binaryTree.RightChild != null)
            {
                DFSPreOrder(binaryTree.RightChild, preOrderTree);
            }
        }

        public void ForEachInOrder(Action<T> action)
        {
            var inOrderTree = new List<IAbstractBinaryTree<T>>();
            DFSInOrder(this, inOrderTree);

            foreach (var item in inOrderTree)
            {
                action(item.Value);
            }
        }
    }
}
