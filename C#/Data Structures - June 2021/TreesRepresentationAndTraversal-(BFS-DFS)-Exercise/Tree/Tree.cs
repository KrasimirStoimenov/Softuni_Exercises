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
            var dfs = new Stack<Tree<T>>();
            dfs.Push(this);

            while (dfs.Count != 0)
            {
                var currentTree = dfs.Pop();

                foreach (var child in currentTree.children)
                {
                    dfs.Push(child);
                }

                if (dfs.Count == 0)
                {
                    deepestLeftmostNode = currentTree;
                }
            }

            return deepestLeftmostNode;
        }

        public List<T> GetLeafKeys()
        {
            var leafKeysList = new List<T>();

            GetAllLeaves(this, leafKeysList);

            return leafKeysList;
        }

        public List<T> GetMiddleKeys()
        {
            var middleNodesKeys = new List<T>();

            GetTreeMiddleNodeKeys(this, middleNodesKeys);

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
            GetAllPathsWithGivenSum(this, ref currentSum, sum, currentPathValues, validPaths);

            return validPaths;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }

        private void GetAllPathsWithGivenSum(
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
                GetAllPathsWithGivenSum(child, ref currentSum, searchedSum, currentPathValues, validPaths);
            }

            if (currentSum == searchedSum)
            {
                validPaths.Add(new List<T>(currentPathValues));
            }

            currentSum -= Convert.ToInt32(tree.Key);
            currentPathValues.RemoveAt(currentPathValues.Count - 1);
        }

        private void GetTreeMiddleNodeKeys(Tree<T> tree, List<T> middleNodesKeys)
        {
            if (tree.Parent != null && tree.children.Count > 0)
            {
                middleNodesKeys.Add(tree.Key);
            }

            foreach (var child in tree.children)
            {
                GetTreeMiddleNodeKeys(child, middleNodesKeys);
            }
        }

        private void GetAllLeaves(Tree<T> tree, List<T> leafKeysList)
        {
            if (tree.children.Count == 0)
            {
                leafKeysList.Add(tree.Key);
            }

            foreach (var child in tree.children)
            {
                GetAllLeaves(child, leafKeysList);
            }
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
    }
}
