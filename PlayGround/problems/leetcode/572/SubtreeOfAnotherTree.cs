using System;
using System.ComponentModel;
using static IBaseSolution;

namespace problems.leetcode._572
{
    public class SubtreeOfAnotherTree : IBaseSolution
    {
        public static readonly Difficulty difficulty = Difficulty.Easy;
        public static readonly Topic topic = Topic.Tree;
        // https://leetcode.com/problems/subtree-of-another-tree/
        public void solve()
        {
            printProblem();
            Solution solution = new Solution();
            Console.WriteLine("root = [3,4,5,1,2], subRoot = [4,1,2], Expected : True");
            Console.WriteLine("Actual: " + solution.IsSubtree(BuildTree([3, 4, 5, 1, 2]), BuildTree([4, 1, 2])));
        }

        public class Solution
        {
            public bool IsSubtree(TreeNode root, TreeNode subRoot)
            {
                if (root == null) return false;
                if (IsSame(root, subRoot)) return true;
                return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
            }

            private bool IsSame(TreeNode s, TreeNode t)
            {
                if (s == null && t == null) return true;
                if (s == null || t == null) return false;
                if (s.val != t.val) return false;
                return IsSame(s.left, t.left) && IsSame(s.right, t.right);
            }
        }

        public TreeNode BuildTree(int?[] values)
        {
            if (values == null || values.Length == 0 || values[0] == null)
                return null;

            TreeNode root = new TreeNode(values[0].Value);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;

            while (i < values.Length)
            {
                TreeNode current = queue.Dequeue();

                // Add left child
                if (i < values.Length && values[i] != null)
                {
                    current.left = new TreeNode(values[i].Value);
                    queue.Enqueue(current.left);
                }
                i++;

                // Add right child
                if (i < values.Length && values[i] != null)
                {
                    current.right = new TreeNode(values[i].Value);
                    queue.Enqueue(current.right);
                }
                i++;
            }

            return root;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }


        public void printProblem()
        {
            Console.Write("Level: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Easy");
            Console.ResetColor();
            Console.WriteLine("Given the roots of two binary trees root and subRoot, return true if there is a subtree of root with the same structure and node values of subRoot and false otherwise.\r\n\r\nA subtree of a binary tree tree is a tree that consists of a node in tree and all of this node's descendants. The tree tree could also be considered as a subtree of itself.\r\n\r\n \r\n\r\nExample 1:\r\n\r\nInput: root = [3,4,5,1,2], subRoot = [4,1,2]\r\nOutput: true\r\nExample 2:\r\n\r\nInput: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]\r\nOutput: false\r\n \r\n\r\nConstraints:\r\n\r\nThe number of nodes in the root tree is in the range [1, 2000].\r\nThe number of nodes in the subRoot tree is in the range [1, 1000].\r\n-104 <= root.val <= 104\r\n-104 <= subRoot.val <= 104");
            Console.WriteLine();
        }

        public void printSource()
        {
            SourcePrinter.PrintSource(this.GetType());
        }
    }
}