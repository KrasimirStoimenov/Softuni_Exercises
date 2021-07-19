namespace Tree
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            var sb = new StringBuilder();
            var ouputString = GetTreeAsString(this, 0, sb).Trim();

            return ouputString;
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            Tree<T> deepestLeftmostNode = null;
            int deepestLevel = 0;
            int currentLevel = 0;
            GetDeepestNodeDFS(this, ref deepestLevel, ref currentLevel, ref deepestLeftmostNode);

            return deepestLeftmostNode;
        }


        public List<T> GetLeafKeys()
        {
            var leafKeysList = new List<T>();

            GetAllLeavesDFS(this, leafKeysList);

            return leafKeysList;
        }

        public List<T> GetMiddleKeys()
        {
            var middleNodesKeys = new List<T>();

            GetTreeMiddleNodeKeysDFS(this, middleNodesKeys);

            return middleNodesKeys.OrderBy(x => x).ToList();
        }

        public List<T> GetLongestPath()
        {
            var deepestLeftmostNode = GetDeepestLeftomostNode();

            var longestPathValues = new List<T>();
            while (deepestLeftmostNode != null)
            {
                longestPathValues.Add(deepestLeftmostNode.Key);
                deepestLeftmostNode = deepestLeftmostNode.Parent;
            }

            longestPathValues.Reverse();
            return longestPathValues;
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var currentPathValues = new List<T>();
            var validPaths = new List<List<T>>();
            var currentSum = 0;
            GetAllPathsWithGivenSumDFS(this, ref currentSum, sum, currentPathValues, validPaths);

            return validPaths;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var validSubtrees = new List<Tree<T>>();
            GetAllValidSubtreesDFS(this, sum, validSubtrees);

            return validSubtrees;
        }

        private string GetTreeAsString(Tree<T> tree, int level, StringBuilder sb)
        {

            var valueToAppend = $"{new string(' ', level)}{tree.Key}";

            sb.AppendLine(valueToAppend);

            foreach (var child in tree.children)
            {
                GetTreeAsString(child, level + 2, sb);
            }

            return sb.ToString();
        }
        private void GetDeepestNodeDFS(Tree<T> tree, ref int deepestLevel, ref int currentLevel, ref Tree<T> deepestLeftmostNode)
        {
            if (deepestLevel < currentLevel)
            {
                deepestLevel = currentLevel;
                deepestLeftmostNode = tree;
            }

            foreach (var child in tree.children)
            {
                ++currentLevel;
                GetDeepestNodeDFS(child, ref deepestLevel, ref currentLevel, ref deepestLeftmostNode);
            }

            --currentLevel;
        }
        private void GetAllLeavesDFS(Tree<T> tree, List<T> leafKeysList)
        {
            if (tree.children.Count == 0)
            {
                leafKeysList.Add(tree.Key);
            }

            foreach (var child in tree.children)
            {
                GetAllLeavesDFS(child, leafKeysList);
            }
        }

        private void GetTreeMiddleNodeKeysDFS(Tree<T> tree, List<T> middleNodesKeys)
        {
            if (tree.Parent != null && tree.children.Count > 0)
            {
                middleNodesKeys.Add(tree.Key);
            }

            foreach (var child in tree.children)
            {
                GetTreeMiddleNodeKeysDFS(child, middleNodesKeys);
            }
        }

        private void GetAllPathsWithGivenSumDFS(
            Tree<T> tree,
            ref int currentSum,
            int searchedSum,
            List<T> currentPathValues,
            List<List<T>> validPaths)
        {
            currentSum += Convert.ToInt32(tree.Key);
            currentPathValues.Add(tree.Key);

            foreach (var child in tree.children)
            {
                GetAllPathsWithGivenSumDFS(child, ref currentSum, searchedSum, currentPathValues, validPaths);
            }

            if (currentSum == searchedSum)
            {
                validPaths.Add(new List<T>(currentPathValues));
            }

            currentSum -= Convert.ToInt32(tree.Key);
            currentPathValues.RemoveAt(currentPathValues.Count - 1);
        }

        private int GetAllValidSubtreesDFS(Tree<T> tree, int sum, List<Tree<T>> validSubtrees)
        {
            var currentSum = Convert.ToInt32(tree.Key);
            foreach (var child in tree.children)
            {
                currentSum += GetAllValidSubtreesDFS(child, sum, validSubtrees);
            }

            if (currentSum == sum)
            {
                validSubtrees.Add(tree);
            }

            return currentSum;
        }
    }
}
